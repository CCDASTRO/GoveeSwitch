using ASCOM.Utilities;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GoveeSwitch
{
    public partial class SetupDialogForm : Form
    {
        // List of devices
        public List<GoveeDevice> Devices { get; set; } = new List<GoveeDevice>();

        public SetupDialogForm()
        {
            InitializeComponent();
            //MessageBox.Show("FORM CONSTRUCTOR HIT");
        }

        /// <summary>
        /// Reads all devices from the ListBox and returns a list.
        /// </summary>
        public List<GoveeDevice> GetDevicesFromForm()
        {
            var updatedDevices = new List<GoveeDevice>();

            foreach (var item in lstDevices_1.Items)
            {
                if (item is GoveeDevice d)
                {
                    updatedDevices.Add(new GoveeDevice
                    {
                        MAC = d.MAC,
                        Model = d.Model,
                        APIKey = d.APIKey,
                        Name = d.Name,
                        State = d.State
                    });
                }
            }

            return updatedDevices;
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            RefreshListBox();
            if (Devices != null && Devices.Count > 0)
                lstDevices_1.SelectedIndex = 0;
        }

        private void RefreshListBox()
        {
            lstDevices_1.Items.Clear();
            foreach (var device in Devices)
                lstDevices_1.Items.Add(device); // ToString() will show Name or MAC
        }

        private void lstDevices_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDevices_1.SelectedIndex < 0) return;

            var device = Devices[lstDevices_1.SelectedIndex];
            txtDeviceName_1.Text = device.Name;
            txtMAC_1.Text = device.MAC;
            txtModel_1.Text = device.Model;
            txtApiKey_1.Text = device.APIKey;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (Devices.Count >= 4)
            {
                MessageBox.Show("Maximum of 4 devices allowed");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMAC_1.Text))
            {
                MessageBox.Show("MAC address required");
                return;
            }

            var device = new GoveeDevice
            {
                Name = txtDeviceName_1.Text.Trim(),
                MAC = txtMAC_1.Text.Trim(),
                Model = txtModel_1.Text.Trim(),
                APIKey = txtApiKey_1.Text.Trim()
            };

            Devices.Add(device);
            RefreshListBox();

            txtDeviceName_1.Text = "";
            txtMAC_1.Text = "";
            txtModel_1.Text = "";
            txtApiKey_1.Text = "";
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (lstDevices_1.SelectedIndex < 0) return;

            int index = lstDevices_1.SelectedIndex;
            var device = Devices[index];

            // Update existing object (NOT creating a new one)
            device.Name = txtDeviceName_1.Text.Trim();
            device.MAC = txtMAC_1.Text.Trim();
            device.Model = txtModel_1.Text.Trim();
            device.APIKey = txtApiKey_1.Text.Trim();

            RefreshListBox();
            lstDevices_1.SelectedIndex = index;
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (lstDevices_1.SelectedIndex < 0) return;

            Devices.RemoveAt(lstDevices_1.SelectedIndex);
            RefreshListBox();

            // Clear fields
            txtDeviceName_1.Text = "";
            txtMAC_1.Text = "";
            txtModel_1.Text = "";
            txtApiKey_1.Text = "";
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            try
            {
                //throw new Exception("BTN OK HIT");
                Devices = GetDevicesFromForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                TraceLogger tl = new TraceLogger("", "GoveeSwitch");
                tl.LogMessage("SetupDialog", ex.ToString());
                MessageBox.Show("Error in SetupDialog: " + ex.Message);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Convenience properties for driver
        public string DeviceMAC => txtMAC_1.Text.Trim();
        public string DeviceModel => txtModel_1.Text.Trim();
        public string APIKey => txtApiKey_1.Text.Trim();
        public string DeviceName => txtDeviceName_1.Text.Trim();
    }
}