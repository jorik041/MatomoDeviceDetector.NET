using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client
{
    public class FeedReaderParser : ClientParserAbstract<List<FeedReader>, ClientMatchResult>
    {
        public FeedReaderParser()
        {
            FixtureFile = "regexes/client/feed_readers.yml";
            ParserName = "feed reader";
            regexList = GetRegexes();
        }
    }
}