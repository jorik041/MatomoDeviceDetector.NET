﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MatomoDeviceDetectorNET.Parser;
using MatomoDeviceDetectorNET.Tests.Class.Client;
using MatomoDeviceDetectorNET.Yaml;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser
{
    [Trait("Category","Os")]

    public class OsTest
    {
        private readonly List<OsFixture> _fixtureData;

        public OsTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\fixtures\oss.yml"}";

            var parser = new YamlParser<List<OsFixture>>();
            _fixtureData = parser.ParseFile(path);

            //replace null
            _fixtureData = _fixtureData.Select(f =>
            {
                f.os.version = f.os.version ?? "";
                return f;
            }).ToList();
        }

        [Fact]
        public void OsTestParse()
        {
            var operatingSystemParser = new OperatingSystemParser();
            foreach (var fixture in _fixtureData)
            {
                operatingSystemParser.SetUserAgent(fixture.user_agent);
                var result = operatingSystemParser.Parse();
                result.Success.Should().BeTrue("Match should be with success");

                result.Match.Name.Should().BeEquivalentTo(fixture.os.name, "Names should be equal");
                result.Match.ShortName.Should().BeEquivalentTo(fixture.os.short_name, "short_names should be equal");
                result.Match.Version.Should().BeEquivalentTo(fixture.os.version, "Versions should be equal");
            }
        }

        [Fact]
        public void TestOSInGroup()
        {
            var AllOs = OperatingSystemParser.GetAvailableOperatingSystems();
            var familiesOs = OperatingSystemParser.GetAvailableOperatingSystemFamilies();
            foreach (var os in AllOs.Keys)
            {
                var contains = false;
                foreach (var familyOs in familiesOs.Values)
                {
                    if (familyOs.Contains(os))
                    {
                        contains = true;
                        return;
                    }
                }
                contains.Should().BeTrue();
            }
        }

        [Fact]
        public void TestGetAvailableOperatingSystems()
        {
            var cout = OperatingSystemParser.GetAvailableOperatingSystems().Count;
            cout.Should().BeGreaterThan(70);
        }

        [Fact]
        public void TestGetAvailabsleOperatingSystemFamilies()
        {
            var cout = OperatingSystemParser.GetAvailableOperatingSystemFamilies().Count;
            cout.Should().Be(23);
        }

        [Theory]
        [InlineData("DEB", "4.5", "Debian 4.5")]
        [InlineData("WRT","", "Windows RT")]
        [InlineData("WIN", "98", "Windows 98")]
        [InlineData("XXX", "4.5", "")]
        public void TestGetNameFromId(string os, string version, string expected)
        {
            var result = OperatingSystemParser.GetNameFromId(os, version);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
