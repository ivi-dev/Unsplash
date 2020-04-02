// <copyright file="SearchPhotosRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class SearchPhotosRequestTest
    {
        [Fact]
        public void SearchPhotosRequest_ArgumentsQueryWithAWhitespace_ProducesAnExpectedURI()
        {
            var query = "a b";
            uint page = 1;
            uint perPage = 5;
            var sort = Sort.LATEST;
            var collections = new[] { "1", "2" };
            var color = ColorFilter.GREEN;
            var orientation = Orientation.SQUARISH;

            var request = new SearchPhotosRequest(query,
                                                  page,
                                                  perPage,
                                                  sort,
                                                  collections,
                                                  color,
                                                  orientation);
            Assert.Matches($"&query={query.Replace(" ", "%20", System.StringComparison.InvariantCulture)}" +
                           $"&page={page}" +
                           $"&per_page={perPage}" +
                           $"&order_by={sort.Describe()}" +
                           $"&collections={collections.Join()}" +
                           $"&color={color.Describe()}" +
                           $"&orientation={orientation.Describe()}",
                           request.Uri.AbsoluteUri);
        }

        [Fact]
        public void SearchPhotosRequest_ArgumentsQueryWithoutAWhitespace_ProducesAnExpectedURI()
        {
            var query = "ab";
            uint page = 1;
            uint perPage = 5;
            var sort = Sort.LATEST;
            var collections = new[] { "1", "2" };
            var color = ColorFilter.GREEN;
            var orientation = Orientation.SQUARISH;

            var request = new SearchPhotosRequest(query,
                                                  page,
                                                  perPage,
                                                  sort,
                                                  collections,
                                                  color,
                                                  orientation);
            Assert.Matches($"&query={query}" +
                           $"&page={page}" +
                           $"&per_page={perPage}" +
                           $"&order_by={sort.Describe()}" +
                           $"&collections={collections.Join()}" +
                           $"&color={color.Describe()}" +
                           $"&orientation={orientation.Describe()}",
                           request.Uri.AbsoluteUri);
        }
    }
}
