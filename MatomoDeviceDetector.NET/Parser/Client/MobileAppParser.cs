using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client
{
    public class MobileAppParser : ClientParserAbstract<List<MobileApp>, ClientMatchResult>
    {
        public MobileAppParser()
        {
            FixtureFile = "regexes/client/mobile_apps.yml";
            ParserName = "mobile app";
            regexList = GetRegexes();
        }
    }
}