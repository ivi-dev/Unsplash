// <copyright file="GetCollectionPhotosRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class GetCollectionPhotosRequestTest
    {
        [Fact]
        public void GetCollectionPhotosRequest_Arguments_ProducesAnExpectedURI()
        {
            var id = "1";
            uint page = 2;
            uint perPage = 15;
            var orientation = Orientation.PORTRAIT;

            var request = new GetCollectionPhotosRequest(id,
                                                         page,
                                                         perPage,
                                                         orientation);
            Assert.Matches($"&page={page}" +
                           $"&per_page={perPage}" +
                           $"&orientation={orientation.Describe()}",
                           request.Uri.AbsoluteUri);
        }
    }
}
