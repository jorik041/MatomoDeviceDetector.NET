﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using MatomoDeviceDetectorNET.Parser.Client;
using MatomoDeviceDetectorNET.Tests.Class.Client;
using MatomoDeviceDetectorNET.Yaml;

namespace MatomoDeviceDetectorNET.Tests.Parser.Client
{
    [Trait("Category", "MobileApp")]
    public class MobileAppTest
    {
        private readonly List<ClientFixture> _fixtureData;

        public MobileAppTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\Client\fixtures\mobile_app.yml"}";

            var parser = new YamlParser<List<ClientFixture>>();
            _fixtureData = parser.ParseFile(path);

            //replace null
            _fixtureData = _fixtureData.Select(f =>
            {
                f.client.version = f.client.version ?? "";
                return f;
            }).ToList();
        }

        [Fact]
        public void MobileAppTestParse()
        {
            var mobileAppParser = new MobileAppParser();
            foreach (var fixture in _fixtureData)
            {
                //@todo:need to be fixed => fixture.user_agent == "Mozilla/5.0 (Linux; U; en-us; BeyondPod)"
                mobileAppParser.SetUserAgent(fixture.user_agent);
                try
                {
                    var result = mobileAppParser.Parse();
                    result.Success.Should().BeTrue("Match should be with success");

                    result.Match.Name.Should().BeEquivalentTo(fixture.client.name, "Names should be equal");
                    result.Match.Type.Should().BeEquivalentTo(fixture.client.type, "Types should be equal");
                    result.Match.Version.Should().BeEquivalentTo(fixture.client.version, "Versions should be equal");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

        }
    }
}
