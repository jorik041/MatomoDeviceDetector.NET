using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client
{
    public class MediaPlayerParser : ClientParserAbstract<List<MediaPlayer>, ClientMatchResult>
    {
        public MediaPlayerParser()
        {
            FixtureFile = "regexes/client/mediaplayers.yml";
            ParserName = "mediaplayer";
            regexList = GetRegexes();
        }
    }
}