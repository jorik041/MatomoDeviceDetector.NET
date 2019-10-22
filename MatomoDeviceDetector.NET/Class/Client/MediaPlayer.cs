using YamlDotNet.Serialization;

namespace MatomoDeviceDetectorNET.Class.Client
{
    public class MediaPlayer: IClientParseLibrary
    {
        [YamlMember(Alias = "regex")]
        public string Regex { get; set; }
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
        [YamlMember(Alias = "version")]
        public string Version { get; set; }
    }
}