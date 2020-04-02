// <copyright file="DownloadPhotoRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using System;
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class DownloadPhotoRequestTest
    {
        [Fact]
        public void DownloadPhotoRequest_ArgumentsQueryWithAWhitespace_ProducesAnExpectedURI()
        {
            var baseUrl = new Uri("http://a.b.c");
            uint width = 200;
            uint height = 100;
            var crop = Crop.EDGES;
            var format = Format.GIF;
            uint quality = 100;
            var fit = Fit.CLAMP;
            uint dpi = 150;

            var request = new DownloadPhotoRequest(baseUrl,
                                                   width,
                                                   height,
                                                   crop,
                                                   format,
                                                   quality,
                                                   fit,
                                                   dpi);
            Assert.Matches($"http://a.b.c/" +
                           $"&w={width}" +
                           $"&h={height}" +
                           $"&crop={crop.Describe()}" +
                           $"&fm={format.Describe()}" +
                           $"&q={quality}" +
                           $"&fit={fit.Describe()}" +
                           $"&dpi={dpi}",
                           request.Uri.AbsoluteUri);
        }
    }
}
