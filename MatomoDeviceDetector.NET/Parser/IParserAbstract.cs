using MatomoDeviceDetectorNET.Cache;

namespace MatomoDeviceDetectorNET.Parser
{
    public interface IParserAbstract
    {
        string FixtureFile { get; }
        string ParserName { get; }

        void SetUserAgent(string ua);
        void SetCache(ICache cacheProvider);
    }
}
