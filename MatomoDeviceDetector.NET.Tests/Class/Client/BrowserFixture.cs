﻿namespace MatomoDeviceDetectorNET.Tests.Class.Client
{

    public class BrowserFixture
    {
        public string user_agent { get; set; }
        public Client client { get; set; }
        public class Client
        {
            public string type { get; set; }
            public string name { get; set; }
            public string short_name { get; set; }
            public string version { get; set; }
            public string engine { get; set; }
            public object engine_version { get; set; }
        }
    }
}
