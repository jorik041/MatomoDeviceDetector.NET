﻿namespace MatomoDeviceDetectorNET.Tests.Class.Client
{
    public class OsFixture
    {
        public string user_agent { get; set; }
        public Os os { get; set; }
        public string client { get; set; }

        public class Os
        {
            public string name { get; set; }
            public string short_name { get; set; }
            public string version { get; set; }
            public string platform { get; set; }
        }
    }
}