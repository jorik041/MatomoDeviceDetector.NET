using YamlDotNet.Serialization;

namespace MatomoDeviceDetectorNET.Class
{
    public class Producer
    {
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
        [YamlMember(Alias = "url")]
        public string Url { get; set; }
    }
}
