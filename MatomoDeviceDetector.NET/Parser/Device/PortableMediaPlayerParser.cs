using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Results;
using MatomoDeviceDetectorNET.Results.Device;

namespace MatomoDeviceDetectorNET.Parser.Device
{
    public class PortableMediaPlayerParser : DeviceParserAbstract<IDictionary<string, DeviceModel>, DeviceMatchResult>
    {
        public PortableMediaPlayerParser()
        {
            FixtureFile = "regexes/device/portable_media_player.yml";
            ParserName = "portablemediaplayer";
            regexList = GetRegexes();
        }

        public override ParseResult<DeviceMatchResult> Parse()
        {
            var result = new ParseResult<DeviceMatchResult>();
            return PreMatchOverall() ? base.Parse() : result;
        }
    }
}