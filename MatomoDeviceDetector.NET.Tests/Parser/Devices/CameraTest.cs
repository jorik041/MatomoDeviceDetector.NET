﻿using System.Collections.Generic;
using FluentAssertions;
using MatomoDeviceDetectorNET.Parser.Device;
using MatomoDeviceDetectorNET.Tests.Class.Client.Device;
using MatomoDeviceDetectorNET.Yaml;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser.Devices
{
    [Trait("Category", "Camera")]
    public class CameraTest
    {
        private readonly List<CameraFixture> _fixtureData;

        public CameraTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\Devices\fixtures\camera.yml"}";

            var parser = new YamlParser<List<CameraFixture>>();
            _fixtureData = parser.ParseFile(path);

            //replace null
            //_fixtureData = _fixtureData.Select(f =>
            //{
            //    f.client.version = f.client.version ?? "";
            //    return f;
            //}).ToList();
        }


        [Fact]
        public void CameraParse()
        {
            var cameraParser = new CameraParser();
            foreach (var fixture in _fixtureData)
            {
                cameraParser.SetUserAgent(fixture.user_agent);
                var result = cameraParser.Parse();
                result.Success.Should().BeTrue("Match should be with success to " + fixture.device.model);

                result.Match.Name.Should().BeEquivalentTo(fixture.device.model, "Names should be equal");
                result.Match.Brand.Should().BeEquivalentTo(fixture.device.brand, "Brand should be equal");
                result.Match.Type.Should().Be(fixture.device.type, "Types should be equal");
            }
        }
    }
}