﻿using System.Collections.Generic;
using FluentAssertions;
using MatomoDeviceDetectorNET.Parser.Device;
using MatomoDeviceDetectorNET.Tests.Class.Client.Device;
using MatomoDeviceDetectorNET.Yaml;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser.Devices
{
    [Trait("Category", "CarBrowserTest")]
    public class CarBrowserTest
    {
        private readonly List<DeviceModelFixture> _fixtureData;

        public CarBrowserTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\Devices\fixtures\car_browser.yml"}";

            var parser = new YamlParser<List<DeviceModelFixture>>();
            _fixtureData = parser.ParseFile(path);

            //replace null
            //_fixtureData = _fixtureData.Select(f =>
            //{
            //    f.client.version = f.client.version ?? "";
            //    return f;
            //}).ToList();
        }


        [Fact]
        public void CarBrowserTestParse()
        {
            var carBrowserParser = new CarBrowserParser();
            foreach (var fixture in _fixtureData)
            {
                carBrowserParser.SetUserAgent(fixture.user_agent);
                var result = carBrowserParser.Parse();
                result.Success.Should().BeTrue("Match should be with success to " + fixture.device.model);

                result.Match.Name.Should().BeEquivalentTo(fixture.device.model, "Names should be equal");
                result.Match.Brand.Should().BeEquivalentTo(fixture.device.brand, "Brand should be equal");
                result.Match.Type.Should().Be(fixture.device.type, "Types should be equal");
            }

        }
    }
}