// <copyright file="ListFeaturedCollectionsRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class ListFeaturedCollectionsRequestTest
    {
        [Fact]
        public void ListFeaturedCollectionsRequest_Arguments_ProducesAnExpectedURI()
        {
            uint page = 2;
            uint perPage = 20;

            var request = new ListFeaturedCollectionsRequest(page, perPage);
            Assert.Matches($"&page={page}" +
                           $"&per_page={perPage}",
                           request.Uri.AbsoluteUri);
        }
    }
}
