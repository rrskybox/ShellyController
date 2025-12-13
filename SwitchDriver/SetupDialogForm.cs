using ASCOM.Utilities;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ASCOM.ShellyRelayController.Switch
{
    [ComVisible(false)] // Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        const string NO_IPADDRESS_MESSAGE = "No IP Addresss found";
        TraceLogger tl; // Holder for a reference to the driver's trace logger

        public SetupDialogForm(TraceLogger tlDriver)
        {
            InitializeComponent();

            // Save the provided trace logger for use within the setup dialogue
            tl = tlDriver;

            // Initialise current values of user settings from the ASCOM Profile
            InitUI();
        }

        private void CmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here and update the state variables with results from the dialogue

            tl.Enabled = chkTrace.Checked;

            // Update the IP Address variable if one has been selected
            if (IPAddressTextBox.Text is null) // No IP Address selected
            {
                tl.LogMessage("Setup OK", $"New configuration values - IP Address: Not selected");
            }
            else if (IPAddressTextBox.Text == NO_IPADDRESS_MESSAGE)
            {
                tl.LogMessage("Setup OK", $"New configuration values - NO IP Addresss detected on this PC.");
            }
            else // A valid ipAddess has been selected
            {
                SwitchHardware.ipAddress = (string)IPAddressTextBox.Text;
                tl.LogMessage("Setup OK", $"New configuration values - IP Address: {IPAddressTextBox.Text}");
            }
        }

        private void CmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("https://ascom-standards.org/");
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {

            // Set the trace checkbox
            chkTrace.Checked = tl.Enabled;

            // set the list of IP Addresss to those that are currently available
            IPAddressTextBox.Clear(); // Clear any existing entries
            // select the current port if possible
            IPAddressTextBox.Text = SwitchHardware.ipAddress;

            // If no ports are found include a message to this effect
            if (IPAddressTextBox.Text == null)
            {
                IPAddressTextBox.Text = NO_IPADDRESS_MESSAGE;
            }


            tl.LogMessage("InitUI", $"Set UI controls to Trace: {chkTrace.Checked}, IP Address: {IPAddressTextBox.Text}");
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {
            // Bring the setup dialogue to the front of the screen
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;
            else
            {
                TopMost = true;
                Focus();
                BringToFront();
                TopMost = false;
            }
        }

        private void ShellyDevicesComboBox_Click(object sender, EventArgs e)
        {

            ShellyDevicesComboBox.Items.Clear();
            foreach (NetworkInterface netInterface in
                NetworkInterface.GetAllNetworkInterfaces())
            {
                IPInterfaceProperties ipProps = netInterface.GetIPProperties();
                foreach (UnicastIPAddressInformation addr in ipProps.UnicastAddresses)

                    ShellyDevicesComboBox.Items.Add(addr.Address.ToString());
            }

        }

        private void ShellyDevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            IPAddressTextBox.Text = ShellyDevicesComboBox.SelectedItem.ToString();
        }

    }
}