using System.Collections.Generic;

namespace ASCOM.ShellyRelayController.Switch
{
    public class Error
    {
        public int code { get; set; }
        public string message { get; set; }
    }

    public class JAPI
    {
        //List of all Shelly request and response classes
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
                        public object name { get; set; }
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
                    config = new Config()
                 };
                
                public class SetConfigRequestParams
                {
                    public int id { get; set; }
                    public Config config { get; set; }
                }

                public class Config
                {
                    public string name { get; set; }
                    //public string in_mode { get; set; }
                    //public bool in_locked { get; set; }
                    //public string initial_state { get; set; }
                    //public bool auto_on { get; set; }
                    //public double auto_on_delay { get; set; }
                    //public bool auto_off { get; set; }
                    //public double auto_off_delay { get; set; }
                    //public bool autorecover_voltage_errors { get; set; }
                    //public int power_limit { get; set; }
                    //public int voltage_limit { get; set; }
                    //public int undervoltage_limit { get; set; }
                    //public double current_limit { get; set; }
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
    }
}








