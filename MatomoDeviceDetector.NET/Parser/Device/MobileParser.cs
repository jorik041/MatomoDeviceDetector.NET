using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Results.Device;

namespace MatomoDeviceDetectorNET.Parser.Device
{
    public class MobileParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        public MobileParser()
        {
            FixtureFile = "regexes/device/mobiles.yml";
            ParserName = "mobiles";
            regexList = GetRegexes();
        }
    }
}