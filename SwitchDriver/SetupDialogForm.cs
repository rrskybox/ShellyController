using ASCOM.Utilities;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ASCOM.ShellyRelayController.Switch
{
    [ComVisible(false)] // Form not registered for COM!
    public partial class SetupDialogForm : Form
    {
        TraceLogger tl; // Holder for a reference to the driver's trace logger

        public SetupDialogForm(TraceLogger tlDriver)
        {
            InitializeComponent();
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // TODO customise this driver description if required
            this.Text = $"Shelly Relay Controller: Version: {version.Major}.{version.Minor}.{version.Build}";

            // Save the provided trace logger for use within the setup dialogue
            tl = tlDriver;

            // Initialise current values of user settings from the ASCOM Profile
            InitUI();

            //Load the switch map data grid
            foreach (var mapping in SwitchHardware.switchMap.GetAllMappings())
            {
                tl.LogMessage("Load Switch Map", mapping.ToString());
                SwitchMapDataGrid.Rows.Add(mapping.SwitchNumber, mapping.DeviceIP, mapping.DeviceMAC, mapping.RelayNumber, mapping.RelayName);
            } 
        }

        private void CmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            // Place any validation constraint checks here and update the state variables with results from the dialogue

            tl.Enabled = chkTrace.Checked;

            // Update the switch map data grid
            if (SwitchHardware.switchMap.GetAllMappings().Count == 0) // No devices selected
            {
                tl.LogMessage("Setup OK", $"Switch Map is empty");
            }
            else
            {
                //Write the relay names out to the devices in case some have been modifified
                for (int i = 0; i < SwitchMapDataGrid.Rows.Count; i++)
                    if (SwitchMapDataGrid.Rows[i].Cells[4].Value != null)
                        SwitchHardware.SetSwitchName((short)i, SwitchMapDataGrid.Rows[i].Cells[4].Value.ToString());
                else
                        SwitchHardware.SetSwitchName((short)i, "Relay " + i.ToString());

                SwitchHardware.WriteProfile();
                tl.LogMessage("Setup OK", $"Switch Map has entries");
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

            if (SwitchHardware.switchMap is null) // No devices selected
            {
                tl.LogMessage("Setup OK", $"Switch Map is empty");
            }
            else
            {
                tl.LogMessage("Setup OK", $"Loading Switch Map");
            }
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

        private void AddDeviceButton_Click(object sender, EventArgs e)
        {
            //Generate Shelly GetConfig Request url and open socket to IP address as entered in IPTextBox
            JAPI.Shelly.GetConfigRequest shellyGetConfigRequest = new JAPI.Shelly.GetConfigRequest();
            JAPI.Shelly.GetConfigResponse.Response shellyGetConfigResponse = new JAPI.Shelly.GetConfigResponse.Response();
            string ipAddress = IPTextBox.Text;
            int switchID = 0;
            int relayID = 0;
            string deviceDscription = "none";
            try
            {
                IPAddress.Parse(ipAddress);
            }
            catch (Exception ex)
            {
                tl.LogMessage("Add Device", $"Add Device = Failed: {ex.Message}");
                return;
            }
            NetIO netIO = new NetIO(ipAddress);
            //Validate IP address as Shelly Device by checking the number of relays on the device
            try
            {
                shellyGetConfigRequest.id = 0;
                shellyGetConfigRequest.@params.id = 0;
                string jsnShellyGetConfigRequest = JsonConvert.SerializeObject(shellyGetConfigRequest);
                string jsnShellyGetConfigResponse = netIO.SendCommand(jsnShellyGetConfigRequest);
                shellyGetConfigResponse = JsonConvert.DeserializeObject<JAPI.Shelly.GetConfigResponse.Response>(jsnShellyGetConfigResponse);
                tl.LogMessage("Add Device", $"Add Device = Successful Device Get Configuration");
            }
            catch (Exception ex)
            {
                tl.LogMessage("Add Device", $"Add Device = Failed: {ex.Message}");
                return;
            }
            //Determine the number of relays on the device
            if (shellyGetConfigResponse.result.switch0 is null)
            {
                tl.LogMessage("Add Device", $"Device at IP Address {ipAddress} is not support switches");
                return;
            }
            switchID = SwitchMapDataGrid.Rows.Count;
            relayID = 0;

            tl.LogMessage("Add Device", $"Switch Number = {switchID.ToString()} Relay Name: {shellyGetConfigResponse.result.switch0.name}");
            SwitchHardware.switchMap.AddMapping(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch0.name);
            SwitchMapDataGrid.Rows.Add(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch0.name);

            if (shellyGetConfigResponse.result.switch1 is null)
            {
                tl.LogMessage("Add Device", $"Device at IP Address {ipAddress} supports one relay");
                return;
            }
            switchID = SwitchMapDataGrid.Rows.Count;
            relayID = 1;
            tl.LogMessage("Add Device", $"Switch Number = {switchID.ToString()} Relay Name: {shellyGetConfigResponse.result.switch1.name}");
            SwitchHardware.switchMap.AddMapping(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch1.name);
            SwitchMapDataGrid.Rows.Add(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch1.name);

            if (shellyGetConfigResponse.result.switch2 is null)
            {
                tl.LogMessage("Add Device", $"Device at IP Address {ipAddress} supports two relays");
                return;
            }
            switchID = SwitchMapDataGrid.Rows.Count;
            relayID = 2;
            tl.LogMessage("Add Device", $"Switch Number = {switchID.ToString()} Relay Name: {shellyGetConfigResponse.result.switch2.name}");
            SwitchHardware.switchMap.AddMapping(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch2.name);
            SwitchMapDataGrid.Rows.Add(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch2.name);

            if (shellyGetConfigResponse.result.switch3 is null)
            {
                tl.LogMessage("Add Device", $"Device at IP Address {ipAddress} supports three relays");
                return;
            }
            switchID = SwitchMapDataGrid.Rows.Count;
            relayID = 3;
            tl.LogMessage("Add Device", $"Switch Number = {switchID.ToString()} Relay Name: {shellyGetConfigResponse.result.switch3.name}");
            SwitchHardware.switchMap.AddMapping(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch3.name);
            SwitchMapDataGrid.Rows.Add(switchID, ipAddress, shellyGetConfigResponse.result.sys.device.mac, relayID, shellyGetConfigResponse.result.switch3.name);

            tl.LogMessage("Add Device", $"Device at IP Address {ipAddress} supports four relays");
            return;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SwitchMapDataGrid.Rows.Clear();
            SwitchHardware.switchMap.ClearMappings();
        }

    }
}
