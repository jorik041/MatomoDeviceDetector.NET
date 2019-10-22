using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class;
using MatomoDeviceDetectorNET.Results;

namespace MatomoDeviceDetectorNET.Parser
{
    /// <summary>
    /// Class BotParserAbstract
    /// Abstract class for all bot parsers
    /// </summary>
    public class BotParser : BotParserAbstract<List<Bot>, BotMatchResult>
    {
        public BotParser()
        {
            FixtureFile = "regexes/bots.yml";
            ParserName = "bot";
            regexList = GetRegexes();
            DiscardDetails = true;
        }  
    }
}