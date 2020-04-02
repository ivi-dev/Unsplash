// <copyright file="GetPhotoStatsRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class GetPhotoStatsRequestTest
    {
        [Fact]
        public void GetPhotoStatsRequest_Arguments_ProducesAnExpectedURI()
        {
            var id = "123";
            var resolution = StatsResolution.DAYS;
            uint quantity = 5;
            var request = new GetPhotoStatsRequest(id, resolution, quantity);
            Assert.Matches($"/{id}", request.Uri.AbsoluteUri);
            Assert.Matches($"&resolution={resolution.Describe()}" +
                           $"&quantity={quantity}",
                           request.Uri.AbsoluteUri);
        }
    }
}
