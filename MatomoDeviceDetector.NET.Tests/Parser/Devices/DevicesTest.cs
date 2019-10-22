using FluentAssertions;
using System.Collections.Generic;
using MatomoDeviceDetectorNET.Class.Device;
using MatomoDeviceDetectorNET.Parser.Device;
using MatomoDeviceDetectorNET.Results.Device;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser.Devices
{
    [Trait("Category", "DevicesTest")]
    public class DevicesTest
    {
        [Fact]
        public void DeviceTypesTest()
        {
            DeviceParserAbstract<Dictionary<string, DeviceModel>, DeviceMatchResult>
                .DeviceTypes
                .Count
                .Should()
                .Be(11);
        }

        [Fact]
        public void DeviceBrandsTest()
        {
            DeviceParserAbstract<Dictionary<string, DeviceModel>, DeviceMatchResult>
                .DeviceBrands
                .Count
                .Should()
                .Be(470);
        }
    }
}
