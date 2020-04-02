// <copyright file="SearchCollectionsRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class SearchCollectionsRequestTest
    {
        [Fact]
        public void SearchCollectionsRequest_ArgumentsQueryWithASpace_ProducesAnExpectedURI()
        {
            var query = "a b";
            uint page = 2;
            uint perPage = 15;

            var request = new SearchCollectionsRequest(query, page, perPage);
            Assert.Matches($"&query={query.Replace(" ", "%20", System.StringComparison.InvariantCulture)}" +
                           $"&page={page}" +
                           $"&per_page={perPage}",
                           request.Uri.AbsoluteUri);
        }
    }
}
