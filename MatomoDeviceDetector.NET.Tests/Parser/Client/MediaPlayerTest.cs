﻿using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using MatomoDeviceDetectorNET.Parser.Client;
using MatomoDeviceDetectorNET.Tests.Class.Client;
using MatomoDeviceDetectorNET.Yaml;
using Xunit;

namespace MatomoDeviceDetectorNET.Tests.Parser.Client
{
    [Trait("Category", "MediaPlayer")]
    public class MediaPlayerTest
    {
        private readonly List<ClientFixture> _fixtureData;

        public MediaPlayerTest()
        {
            var path = $"{Utils.CurrentDirectory()}\\{@"Parser\Client\fixtures\mediaplayer.yml"}";

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
        public void MediaPlayerTestParse()
        {
            var mediaPlayerParser = new MediaPlayerParser();
            foreach (var fixture in _fixtureData)
            {
                mediaPlayerParser.SetUserAgent(fixture.user_agent);
                var result = mediaPlayerParser.Parse();
                result.Success.Should().BeTrue("Match should be with success");

                result.Match.Name.Should().BeEquivalentTo(fixture.client.name,"Names should be equal");
                result.Match.Type.Should().BeEquivalentTo(fixture.client.type, "Types should be equal");
                result.Match.Version.Should().BeEquivalentTo(fixture.client.version, "Versions should be equal");
            }

        }
    }
}
