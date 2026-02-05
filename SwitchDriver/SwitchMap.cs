using ASCOM.ShellyRelayController.Switch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ASCOM.ShellyRelayController.Switch
{
    public class SwitchMap
    {
        //Maps Shelly relay ip, mac address and relay number to ASCOM switch number

        List<SwitchMapping> switchMappings = new List<SwitchMapping>();

        public class SwitchMapping
        {
            public int SwitchNumber { get; set; }
            public string DeviceIP { get; set; }
            public string DeviceMAC { get; set; }
            public int RelayNumber { get; set; }
            public string RelayName { get; set; }
        }

        public SwitchMap(string encodedString)
        {
            switchMappings.Clear();
            List<string> mappings = encodedString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string mapping in mappings)
            {
                string[] parts = mapping.Split(new char[] { ',' });
                if (parts.Length == 5)
                {
                    int switchNumber = int.Parse(parts[0]);
                    string shellyIP = parts[1];
                    string shellyMac = parts[2];
                    int shellyRelayNumber = int.Parse(parts[3]);
                    string shellyRelayName = parts[4];
                    AddMapping(switchNumber, shellyIP, shellyMac, shellyRelayNumber, shellyRelayName);
                }
            }
        }

        public void ClearMappings()
        {
            switchMappings.Clear();
        }

        public bool HasMapping(int switchNumber)
        {
            return switchMappings.Any(m => m.SwitchNumber == switchNumber);
        }

        // Returns the highest switch number in the mapping, or -1 if no mappings exist
        public int MaxSwitchNumber
        {
            get
            {
                if (switchMappings.Count == 0)
                {
                    return -1;
                }
                return switchMappings.Max(m => m.SwitchNumber);
            }
        }

        //returns all mappings in a list
        public List<SwitchMapping> GetAllMappings()
        {
            return switchMappings;
        }

        public void DecodeSwitchMap(string encodedString)
        {
            switchMappings.Clear();
            List<string> mappings = encodedString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string mapping in mappings)
            {
                string[] parts = mapping.Split(new char[] { ',' });
                if (parts.Length == 5)
                {
                    int switchNumber = int.Parse(parts[0]);
                    string shellyIP = parts[1];
                    string shellyMac = parts[2];
                    int shellyRelayNumber = int.Parse(parts[3]);
                    string shellyRelayName = parts[4];
                    AddMapping(switchNumber, shellyIP, shellyMac, shellyRelayNumber, shellyRelayName);
                }
            }
        }

        public string EncodeSwitchMap()
        {
            string encodeMap = "";
            foreach (var mapping in switchMappings)
            {
                encodeMap += $"{mapping.SwitchNumber},{mapping.DeviceIP},{mapping.DeviceMAC},{mapping.RelayNumber},{mapping.RelayName};";
            }
            return encodeMap;
        }

        public string ReadDeviceIP(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            return mapping?.DeviceIP;
        }

        public string ReadDeviceMac(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            return mapping?.DeviceMAC;
        }

        public string ReadRelayNumber(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            return mapping != null ? mapping.RelayNumber.ToString() : null;
        }

        public void DeleteMapping(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            if (mapping != null)
            {
                switchMappings.Remove(mapping);
            }
        }

        public void AddMapping(int switchNumber, string shellyIP, string shellyMac, int shellyRelayNumber, string shellyRelayName)
        {
            DeleteMapping(switchNumber);
            switchMappings.Add(new SwitchMapping
            {
                SwitchNumber = switchNumber,
                DeviceIP = shellyIP,
                DeviceMAC = shellyMac,
                RelayNumber = shellyRelayNumber,
                RelayName = shellyRelayName,
            });
        }

        public string ReadDeviceDescription(int switchNumber)
        {
            string ipAddress = ReadDeviceIP(switchNumber);
            NetIO netIO = new NetIO(ipAddress);
            JAPI.Sys.GetConfigRequest scfgRequest = new JAPI.Sys.GetConfigRequest();
            string sjsnRequest = JsonConvert.SerializeObject(scfgRequest);
            string sjsnResponse = netIO.SendCommand(sjsnRequest);
            JAPI.Sys.GetConfigResponse.Response sysRoot = JsonConvert.DeserializeObject<JAPI.Sys.GetConfigResponse.Response>(sjsnResponse);
            string deviceDescription = sysRoot.src.Split('-')[0].Trim(new char[] { '"' });
            return deviceDescription;
        }

        public string ReadRelayName(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            return mapping.RelayName ?? "";
            //string ipAddress = ReadDeviceIP(switchNumber);
            //NetIO netIO = new NetIO(ipAddress);
            //JAPI.Switch.GetConfigRequest getCfgRequest = new JAPI.Switch.GetConfigRequest();
            //getCfgRequest.id = 0;
            //getCfgRequest.@params.id = switchNumber;
            //var jsnResponse = netIO.SendCommand(JsonConvert.SerializeObject(getCfgRequest));
            //JAPI.Switch.GetConfigResponse.Response getSwitchResponse =
            //    JsonConvert.DeserializeObject<JAPI.Switch.GetConfigResponse.Response>(jsnResponse);
            //if (getSwitchResponse.error != null)
            //{
            //    throw new ASCOM.DriverException(getSwitchResponse.error.message);
            //}
            //return getSwitchResponse.result.name ?? "";
        }
        public string ReadRelayDescription(int switchNumber)
        {
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            string relayDescription = ReadDeviceDescription(switchNumber);
            return relayDescription + " Relay " + mapping.RelayNumber.ToString();
        }

        public void WriteRelayName(int switchNumber, string relayName)
        {
            string ipAddress = ReadDeviceIP(switchNumber);
            NetIO netIO = new NetIO(ipAddress);
            JAPI.Switch.SetConfigRequest setCfgRequest = new JAPI.Switch.SetConfigRequest();
            setCfgRequest.id = 0;
            setCfgRequest.@params.id = switchNumber;
            setCfgRequest.@params.config.name = relayName;
            var jsnResponse = netIO.SendCommand(JsonConvert.SerializeObject(setCfgRequest));
            JAPI.Switch.SetConfigResponse.Response setSwitchResponse = JsonConvert.DeserializeObject<JAPI.Switch.SetConfigResponse.Response>(jsnResponse);
            var mapping = switchMappings.FirstOrDefault(m => m.SwitchNumber == switchNumber);
            mapping.RelayName = relayName;
            return;
        }


        #region device characteristics



        #endregion
    }
}

