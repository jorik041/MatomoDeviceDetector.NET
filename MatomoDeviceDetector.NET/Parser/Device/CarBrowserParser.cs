using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Results;
using MatomoDeviceDetectorNET.Results.Device;

namespace MatomoDeviceDetectorNET.Parser.Device
{
    public class CarBrowserParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        public CarBrowserParser()
        {
            FixtureFile = "regexes/device/car_browsers.yml";
            ParserName = "car browser";
            regexList = GetRegexes();
        }

        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return PreMatchOverall() ? base.Parse() : result;
        }
    }
}
