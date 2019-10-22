using System.Collections.Generic;
using System.Linq;
using MatomoDeviceDetectorNET.Class.Client;
using MatomoDeviceDetectorNET.Results;
using MatomoDeviceDetectorNET.Results.Client;

namespace MatomoDeviceDetectorNET.Parser.Client.Browser.Engine
{
    public class VersionParser : ClientParserAbstract<List<IClientParseLibrary>, ClientMatchResult>
    {
        private readonly string _engine;
        public VersionParser(string ua, string engine):base(ua)
        {
            _engine = engine;
        }

        public override ParseResult<ClientMatchResult> Parse()
        {
            var result = new ParseResult<ClientMatchResult>();
            if (string.IsNullOrEmpty(_engine))
            {
                return result;
            }
            var matches = GetRegexEngine().MatchesUniq(UserAgent,_engine + @"\s*\/?\s*((?(?=\d+\.\d)\d+[.\d]*|\d{1,7}(?=(?:\D|$))))").ToArray();
            if (matches.Length <= 0) return result;
            foreach (var match in matches)
            {
                result.Add(new ClientMatchResult { Name = match });
                
            }
            return result;
            //return base.Parse();
        }
    }
}