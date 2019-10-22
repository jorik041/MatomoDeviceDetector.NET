using System.Collections.Generic;
using System.Linq;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Parser.Device;
using MatomoDeviceDetectorNET.Results;

namespace MatomoDeviceDetectorNET.Parser
{
    public class VendorFragmentParser : ParserAbstract<Dictionary<string,string[]>, VendorFragmentResult>
    {
        public VendorFragmentParser()
        {
            FixtureFile = "regexes/vendorfragments.yml";
            ParserName = "vendorfragments";
            regexList = GetRegexes();
        }

        public override ParseResult<VendorFragmentResult> Parse()
        {
            var result = new ParseResult<VendorFragmentResult>();
            foreach (var brands in regexList)
            {
                foreach (var brand in brands.Value)
                {
                    if (IsMatchUserAgent(brand + "[^a-z0-9]+"))
                    {
                        result.Add(new VendorFragmentResult
                        {
                            Name = brands.Key,
                            Brand = DeviceParserAbstract<IDictionary<string, DeviceModel>, VendorFragmentResult>.DeviceBrands
                                .FirstOrDefault(d => d.Value.Equals(brands.Key)).Key
                        });
                    }
                }
            }
            return result;
        }
    }
}
