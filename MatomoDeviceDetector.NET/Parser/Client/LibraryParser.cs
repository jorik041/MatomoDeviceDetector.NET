using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client
{
    public class LibraryParser : ClientParserAbstract<List<Library>, ClientMatchResult>
    {
        public LibraryParser()
        {
            FixtureFile = "regexes/client/libraries.yml";
            ParserName = "library";
            regexList = GetRegexes();
        }
    }
}