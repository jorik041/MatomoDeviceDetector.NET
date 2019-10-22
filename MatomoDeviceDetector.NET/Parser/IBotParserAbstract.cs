namespace MatomoDeviceDetectorNET.Parser
{
    public interface IBotParserAbstract: IParserAbstract
    {
        bool DiscardDetails { get; set; }
    }
}