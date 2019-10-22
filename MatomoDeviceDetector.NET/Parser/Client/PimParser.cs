using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client
{
    public class PimParser : ClientParserAbstract<List<Pim>, ClientMatchResult>
    {
        public PimParser()
        {
            FixtureFile = "regexes/client/pim.yml";
            ParserName = "pim";
            regexList = GetRegexes();
        }
    }
}