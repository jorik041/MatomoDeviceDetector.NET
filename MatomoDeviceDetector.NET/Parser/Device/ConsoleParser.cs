using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Results;
using MatomoDeviceDetectorNET.Results.Device;

namespace MatomoDeviceDetectorNET.Parser.Device
{
    public class ConsoleParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        public ConsoleParser()
        {
            FixtureFile = "regexes/device/consoles.yml";
            ParserName = "consoles";
            regexList = GetRegexes();
        }

        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return PreMatchOverall() ? base.Parse() : result;
        }
    }
}