using ASCOM.DeviceInterface;
using ASCOM.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GoveeSwitch
{

    [ComVisible(true)]
    [Guid("6129C7FF-3D53-491A-A93B-538583FA8376")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("ASCOM.Govee.Switch")]
    public class Driver : ISwitchV2, IDisposable
    {
        private const string driverID = "ASCOM.Govee.Switch";
        private bool connectedState = false;
        private TraceLogger tl;
        
        private List<GoveeDevice> devices = new List<GoveeDevice>();
        private int currentDeviceIndex = 0;
        #region COM Registration

        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            Profile profile = new Profile { DeviceType = "Switch" };
            profile.Register(driverID, "Govee Switch");
        }

        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            Profile profile = new Profile { DeviceType = "Switch" };
            profile.Unregister(driverID);
        }

        #endregion
        public Driver()
        {
            //MessageBox.Show("Driver constructor hit");
            tl = new TraceLogger("", driverID);
            tl.Enabled = true;
            tl.LogMessage("Driver", "Initialized");

            ReadProfile();
        }

        #region ISwitchV2 Implementation

        public bool Connected
        {
            get => connectedState;
            set
            {
                connectedState = value;
                tl.LogMessage("Connected", value.ToString());
            }
        }

        public string Description => "Govee Switch";
        public string DriverInfo => "Govee Switch Driver with Setup Dialog";
        public string DriverVersion => "1.0";
        public short InterfaceVersion => 2;
        public string Name => "Govee Switch";

        public short MaxSwitch => 1;
        public ArrayList SupportedActions => new ArrayList();
        public bool CanWrite(short id)
        {
            Validate(id);
            return true;
        }

        public bool GetSwitch(short id)
        {
            Validate(id);
            return devices.Count > 0 ? devices[currentDeviceIndex].State : false;
        }

        public void SetSwitch(short id, bool value)
        {
            Validate(id);
            if (devices.Count == 0) return;

            devices[currentDeviceIndex].State = value;
            SendCommand(devices[currentDeviceIndex], value);
            tl.LogMessage("SetSwitch", value.ToString());
        }

        public double GetSwitchValue(short id) => GetSwitch(id) ? 1 : 0;
        public void SetSwitchValue(short id, double value)
        {
            Validate(id);

            double min = MinSwitchValue(id);
            double max = MaxSwitchValue(id);

            if (value < min || value > max)
                throw new ASCOM.InvalidValueException($"Value {value} is outside allowed range [{min}, {max}]");

            SetSwitch(id, value > 0.5);
        }

        public double MinSwitchValue(short id)
        {
            Validate(id);
            return 0;
        }

        public double MaxSwitchValue(short id)
        {
            Validate(id);
            return 1;
        }
        public double SwitchStep(short id)
        {
            Validate(id);
            return 1;
        }

        public string GetSwitchName(short id)
        {
            Validate(id);
            return devices.Count > 0 ? devices[currentDeviceIndex].Name : "Govee Device";
        }

        public void SetSwitchName(short id, string name)
        {
            if (devices.Count > 0)
                devices[currentDeviceIndex].Name = name;
        }

        public string GetSwitchDescription(short id)
        {
            Validate(id);
            return "Govee Device";
        }

        public void SetupDialog()
        {
            try
            {
                ReadProfile();  // ← MUST happen first

                using (var dlg = new SetupDialogForm())
                {
                    dlg.Devices = new List<GoveeDevice>(devices);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        devices = dlg.Devices;
                        WriteProfile(); // ← Save to ASCOM profile
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SetupDialog error:\n\n" + ex.ToString());
            }
        }

        public string Action(string ActionName, string ActionParameters) => throw new ASCOM.MethodNotImplementedException("Action not implemented");
        public void CommandBlind(string Command, bool Raw = false) => throw new ASCOM.MethodNotImplementedException("CommandBlind not implemented");
        public bool CommandBool(string Command, bool Raw = false) => throw new ASCOM.MethodNotImplementedException("CommandBool not implemented");
        public string CommandString(string Command, bool Raw = false) => throw new ASCOM.MethodNotImplementedException("CommandString not implemented");

        #endregion

        #region Private Helpers

        private void Validate(short id)
        {
            if (id != 0)
                throw new ASCOM.InvalidValueException("Only switch 0 is valid");
        }

        private void SendCommand(GoveeDevice device, bool on)
        {
            try
            {
                string url = "https://developer-api.govee.com/v1/devices/control";

                string json = $@"{{""device"":""{device.MAC}"",""model"":""{device.Model}"",""cmd"":{{""name"":""turn"",""value"":""{(on ? "on" : "off")}""}}}}";

                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "PUT";
                request.ContentType = "application/json";
                request.Headers.Add("Govee-API-Key", device.APIKey);

                byte[] data = Encoding.UTF8.GetBytes(json);
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                    stream.Write(data, 0, data.Length);

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    tl.LogMessage("HTTP", response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                tl.LogMessage("ERROR", ex.Message);
            }
        }

        #endregion

        #region ASCOM Profile Management

        private void ReadProfile()
        {
            try
            {
                var profile = new Profile();
                profile.DeviceType = "Switch";

                devices.Clear();

                int count = int.Parse(profile.GetValue(driverID, "DeviceCount", "", "0"));

                //MessageBox.Show($"ReadProfile: found {count} devices"); // DEBUG

                for (int i = 0; i < count; i++)
                {
                    var d = new GoveeDevice
                    {
                        MAC = profile.GetValue(driverID, $"Device{i}_MAC", ""),
                        Model = profile.GetValue(driverID, $"Device{i}_Model", ""),
                        APIKey = profile.GetValue(driverID, $"Device{i}_APIKey", ""),
                        Name = profile.GetValue(driverID, $"Device{i}_Name", ""),
                        State = false
                    };

                    devices.Add(d);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ReadProfile ERROR:\n" + ex.ToString());
            }
        }


        private void WriteProfile()
{
    try
    {
        if (devices == null)
            devices = new List<GoveeDevice>();

        //MessageBox.Show($"WriteProfile: devices={devices.Count}"); // Debug

        var profile = new Profile();
        profile.DeviceType = "Switch";

        // Use the same driverID / ProgID for registration
        string profileKey = "ASCOM.Govee.Switch";

        // Always write DeviceCount
        profile.WriteValue(profileKey, "DeviceCount", devices.Count.ToString());

        for (int i = 0; i < devices.Count; i++)
        {
            var d = devices[i];

            if (d == null)
            {
                MessageBox.Show($"Skipping null device at index {i}");
                continue;
            }

            // Ensure no field is null
            string mac = d.MAC?.Trim() ?? "";
            string model = d.Model?.Trim() ?? "";
            string api = d.APIKey?.Trim() ?? "";
            string name = d.Name?.Trim() ?? "";

            // Skip completely empty devices (optional)
            if (string.IsNullOrEmpty(mac) &&
                string.IsNullOrEmpty(model) &&
                string.IsNullOrEmpty(api))
            {
                MessageBox.Show($"Skipping empty device at index {i}");
                continue;
            }

            profile.WriteValue(profileKey, $"Device{i}_MAC", mac);
            profile.WriteValue(profileKey, $"Device{i}_Model", model);
            profile.WriteValue(profileKey, $"Device{i}_APIKey", api);
            profile.WriteValue(profileKey, $"Device{i}_Name", name);
        }

       // MessageBox.Show("WriteProfile completed successfully"); //Debug
    }
    catch (Exception ex)
    {
        MessageBox.Show("WriteProfile ERROR:\n" + ex.ToString());
    }
}

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            tl?.Dispose();
        }

        #endregion

        
    }

    public class GoveeDevice
    {
        public string MAC { get; set; }
        public string Model { get; set; }
        public string APIKey { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }

        public override string ToString() => string.IsNullOrWhiteSpace(Name) ? MAC : Name;
    }
}