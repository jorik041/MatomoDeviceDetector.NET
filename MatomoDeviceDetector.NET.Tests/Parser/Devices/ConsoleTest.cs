﻿using System.Collections.Generic;
using FluentAssertions;
using MatomoDeviceDetectorNET.Parser.Device;
using MatomoDeviceDetectorNET.Tests.Class.Client.Device;
using MatomoDeviceDetectorNET.Yaml;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser.Devices
{
    [Trait("Category", "ConsoleTest")]
    public class ConsoleTest
    {
        private readonly List<DeviceModelFixture> _fixtureData;

        public ConsoleTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\Devices\fixtures\console.yml"}";

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
        public void ConsoleTestParse()
        {
            var consoleParser = new ConsoleParser();
            foreach (var fixture in _fixtureData)
            {
                consoleParser.SetUserAgent(fixture.user_agent);
                var result = consoleParser.Parse();
                result.Success.Should().BeTrue("Match should be with success to " + fixture.device.model);

                result.Match.Name.Should().BeEquivalentTo(fixture.device.model, "Names should be equal");
                result.Match.Brand.Should().BeEquivalentTo(fixture.device.brand, "Brand should be equal");
                result.Match.Type.Should().Be(fixture.device.type, "Types should be equal");
            }
        }

        [Fact]
        public void Test()
        {
            var ua = @"Mozilla/5.0 (Linux; Android 4.2.2; ARCHOS 101 PLATINUM Build/JDQ39) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/34.0.1847.114 Safari/537.36";
            var consoleParser = new ConsoleParser();
            consoleParser.SetUserAgent(ua);
            var result = consoleParser.Parse();
        }
    }
}