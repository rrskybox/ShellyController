using ASCOM.LocalServer;
using ASCOM.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using static ASCOM.ShellyRelayController.Switch.JAPI.Switch.GetStatusResponse.Response;
using static ASCOM.ShellyRelayController.Switch.JAPI.Sys.GetStatusResponse.Response;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace ASCOM.ShellyRelayController.Switch
{
    public class JAPI
    {
        //List of all Shelly request and response classes
        public class Shelly
        {
            public class GetConfigRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Shelly.GetConfig";
                public GetConfigRequestParams @params { get; set; } = new GetConfigRequestParams()
                {
                    id = 1
                };
                public class GetConfigRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetConfigResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }
                    public class Result
                    {
                        [JsonProperty("sys")]
                        public Sys.GetConfigResponse.Response.Result sys { get; set; }

                        [JsonProperty("switch:0")]
                        public Switch.GetConfigResponse.Response.Result switch0 { get; set; }

                        [JsonProperty("switch:1")]
                        public Switch.GetConfigResponse.Response.Result switch1 { get; set; }

                        [JsonProperty("switch:2")]
                        public Switch.GetConfigResponse.Response.Result switch2 { get; set; }

                        [JsonProperty("switch:3")]
                        public Switch.GetConfigResponse.Response.Result switch3 { get; set; }

                    }
                }
            }

            public class GetStatusRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Shelly.GetStatus";
                public GetStatusRequestParams @params { get; set; } = new GetStatusRequestParams()
                {
                    id = 1
                };
                public class GetStatusRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetStatusResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }
                    public class Result
                    {
                        public string uptime { get; set; }
                        public string ram_total { get; set; }
                        public string ram_free { get; set; }
                        public string fs_size { get; set; }
                        public string fs_free { get; set; }
                        public string wifi_sta_ip { get; set; }
                        public string wifi_sta_rssi { get; set; }
                        public string wifi_ap_ip { get; set; }
                        public bool mqtt_connected { get; set; }
                        public bool cloud_connected { get; set; }
                        public bool time_synced { get; set; }
                    }
                }
            }

            public class GetDeviceInfoRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Shelly.GetDeviceInfo";
                public GetDeviceInfoRequestParams @params { get; set; } = new GetDeviceInfoRequestParams()
                {
                    id = 1
                };
                public class GetDeviceInfoRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetDeviceInfoResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }
                    public class Result
                    {
                        public string model { get; set; }
                        public string mac { get; set; }
                        public string fw_id { get; set; }
                        public string hw_id { get; set; }
                        public string serial { get; set; }
                        public string dev_type { get; set; }
                    }
                }
            }

        }

        public class Sys
        {
            public class GetConfigRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Sys.GetConfig";
                public GetConfigRequestParams @params { get; set; } = new GetConfigRequestParams()
                {
                    id = 2
                };

                public class GetConfigRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetConfigResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public Device device { get; set; }
                        public Location location { get; set; }
                        public Debug debug { get; set; }
                        public UiData ui_data { get; set; }
                        public RpcUdp rpc_udp { get; set; }
                        public Sntp sntp { get; set; }
                        public int cfg_rev { get; set; }
                    }

                    public class Debug
                    {
                        public Mqtt mqtt { get; set; }
                        public Websocket websocket { get; set; }
                        public Udp udp { get; set; }
                    }

                    public class Device
                    {
                        public string name { get; set; }
                        public string mac { get; set; }
                        public string fw_id { get; set; }
                        public bool eco_mode { get; set; }
                        public string profile { get; set; }
                        public bool discoverable { get; set; }
                    }

                    public class Location
                    {
                        public string tz { get; set; }
                        public double lat { get; set; }
                        public double lon { get; set; }
                    }

                    public class Mqtt
                    {
                        public bool enable { get; set; }
                    }


                    public class RpcUdp
                    {
                        public object dst_addr { get; set; }
                        public object listen_port { get; set; }
                    }

                    public class Sntp
                    {
                        public string server { get; set; }
                    }

                    public class Udp
                    {
                        public object addr { get; set; }
                    }

                    public class UiData
                    {
                    }

                    public class Websocket
                    {
                        public bool enable { get; set; }
                    }


                }

            }

            public class GetStatusRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Sys.GetStatus";
                public GetStatusRequestParams @params { get; set; } = new GetStatusRequestParams()
                {
                    id = 2
                };

                public class GetStatusRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetStatusResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public string mac;  // Mac address of the device
                        public bool restart_required; // True if restart is required, false otherwise
                        public string time;  // Current time in the format HH:MM(24-hour time format in the current timezone with leading zero).
                                             // null when time is not synced from NTP server.
                        public double unixtime;  // Unix timestamp(in UTC), null when time is not synced from NTP server.
                        public double last_sync_ts;  // Last time the system synced time from NTP server(in UTC), null when time is not synced from NTP server.
                        public double uptime;  // Time in seconds since last reboot
                        public double ram_size;  // Total size of the RAM in the system in Bytes
                        public double ram_free;  // Size of the free RAM in the system in Bytes
                        public double fs_size;  // Total size of the file system in Bytes
                        public double fs_free;  // Size of the free file system in Bytes
                        public double cfg_rev;  // Configuration revision number
                        public double kvs_rev;  // KVS(Key-Value Store) revision number
                        public double schedule_rev;  // Schedules revision number, present if schedules are enabled
                        public double webhook_rev;  // Webhooks revision number, present if webhooks are enabled
                        public double knx_rev;  // KNX configuration revision number, present on devices supporting KNX with KNX enabled
                        public double btrelay_rev;  // BLE cloud relay configuration revision number, present on devices supporting BLE cloud relay functionality
                        public double bthc_rev;  // BTHomeControl configuration revision number, present when device supports control with BLU devices
                        public AvailableUpdates available_updates { get; set; }  // Information about available updates, similar to the one returned by Shelly.
                                                                                 // CheckForUpdate(empty object: {}, if no updates available).
                                                                                 // This information is automatically updated every 24 hours.Note that build_id and
                                                                                 // url for an update are not displayed here
                        public WakeupReason wakeup_reason { get; set; }  // Information about boot type and cause(only for battery-operated devices)
                        public double wakeup_period;  //Period(in seconds) at which device wakes up and sends "keep-alive" packet to cloud, readonly.
                                                      //Count starts from last full wakeup
                        public double utc_offset;  // Time offset(in seconds). This is the difference between the device local time and UTC
                    }

                    public class AvailableUpdates
                    {
                        beta Beta { get; set; }
                    }

                    public class beta
                    {
                        string version { get; set; }
                    }

                    public class WakeupReason
                    {
                        string boottype { get; set; }
                        string cause { get; set; }
                    }
                }
            }
        }

        public class Switch
        {
            public class GetConfigRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Switch.GetConfig";
                public GetConfigRequestParams @params { get; set; } = new GetConfigRequestParams()
                {
                    id = 0
                };

                public class GetConfigRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetConfigResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public int id { get; set; }
                        public string name { get; set; }
                        public string in_mode { get; set; }
                        public bool in_locked { get; set; }
                        public string initial_state { get; set; }
                        public bool auto_on { get; set; }
                        public double auto_on_delay { get; set; }
                        public bool auto_off { get; set; }
                        public double auto_off_delay { get; set; }
                        public bool autorecover_voltage_errors { get; set; }
                        public int power_limit { get; set; }
                        public int voltage_limit { get; set; }
                        public int undervoltage_limit { get; set; }
                        public double current_limit { get; set; }
                        public bool reverse { get; set; }
                    }
                }
            }

            public class SetConfigRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 1;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Switch.SetConfig";
                public SetConfigRequestParams @params { get; set; } = new SetConfigRequestParams()
                {
                    id = 0,
                    config = new SetConfig()
                };

                public class SetConfigRequestParams
                {
                    public int id { get; set; }
                    public SetConfig config { get; set; }
                }

                public class SetConfig
                {
                    public string name { get; set; }
                    public string in_mode { get; set; }
                    public bool in_locked { get; set; }
                    public string initial_state { get; set; }
                    public bool auto_on { get; set; }
                    public double auto_on_delay { get; set; }
                    public bool auto_off { get; set; }
                    public double auto_off_delay { get; set; }
                    public bool autorecover_voltage_errors { get; set; }
                    public int power_limit { get; set; }
                    public int voltage_limit { get; set; }
                    public int undervoltage_limit { get; set; }
                    public double current_limit { get; set; }
                }
            }

            public class SetConfigResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public int id { get; set; }
                        public string name { get; set; }
                        public string in_mode { get; set; }
                        public bool in_locked { get; set; }
                        public string initial_state { get; set; }
                        public bool auto_on { get; set; }
                        public double auto_on_delay { get; set; }
                        public bool auto_off { get; set; }
                        public double auto_off_delay { get; set; }
                        public bool autorecover_voltage_errors { get; set; }
                        public int power_limit { get; set; }
                        public int voltage_limit { get; set; }
                        public int undervoltage_limit { get; set; }
                        public double current_limit { get; set; }
                    }
                }
            }

            public class GetStatusRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 0;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Switch.GetStatus";
                public GetConfigRequestParams @params { get; set; } = new GetConfigRequestParams()
                {
                    id = 0
                };

                public class GetConfigRequestParams
                {
                    public int id { get; set; }
                }
            }

            public class GetStatusResponse
            {
                public class Response
                {
                    public int id { get; set; }

                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public int id { get; set; }
                        public string source { get; set; }
                        public bool output { get; set; }
                        public double apower { get; set; }
                        public double voltage { get; set; }
                        public double current { get; set; }
                        public double freq { get; set; }
                        public string[] errors { get; set; }
                        public Aenergy aenergy { get; set; }
                        public RetAenergy ret_aenergy { get; set; }
                        public Temperature temperature { get; set; }
                    }

                    public class Aenergy
                    {
                        public double total { get; set; }
                        public List<double> by_minute { get; set; }
                        public int minute_ts { get; set; }
                    }

                    public class RetAenergy
                    {
                        public double total { get; set; }
                        public List<double> by_minute { get; set; }
                        public int minute_ts { get; set; }
                    }

                    public class Temperature
                    {
                        public double tC { get; set; }
                        public double tF { get; set; }
                    }
                }
            }

            public class SetSwitchRequest
            {
                public string jsonrpc { get; set; } = "2.0";
                public int id { get; set; } = 2;
                public string src { get; set; } = "user_1";
                public string method { get; set; } = "Switch.Set";
                public SetSwitchRequestParams @params { get; set; } = new SetSwitchRequestParams()
                {
                    id = 2,
                    on = false
                };
                public class SetSwitchRequestParams
                {
                    public int id { get; set; }
                    public bool on { get; set; }
                }
            }

            public class SetSwitchResponse
            {
                public class Response
                {
                    public int id { get; set; }
                    public string src { get; set; }
                    public string dst { get; set; }
                    public Result result { get; set; }
                    public Error error { get; set; }

                    public class Result
                    {
                        public int id { get; set; }
                        public bool was_on { get; set; }
                    }

                }
            }
        }

        public class Error
        {
            public int code { get; set; }
            public string message { get; set; }
        }


    }
}








