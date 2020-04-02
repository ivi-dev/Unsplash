// <copyright file="GetRandomPhotoRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class GetRandomPhotoRequestTest
    {
        [Fact]
        public void GetRandomPhotoRequest_UsernameAndQueryWithSpaces_ProducesAnExpectedURI()
        {
            var orientation = Orientation.PORTRAIT;
            var collections = new[] { "1", "2" };
            var featured = true;
            var username = "A B";
            var query = "C D";
            var request = new GetRandomPhotoRequest(orientation,
                                                    collections,
                                                    featured,
                                                    username,
                                                    query);
            Assert.Matches($"&orientation={orientation.Describe()}" +
                           $"&collections={collections.Join()}" +
                           $"&featured={featured}" +
                           $"&username={username.Replace(" ", "%20", System.StringComparison.InvariantCulture)}" +
                           $"&query={query.Replace(" ", "%20", System.StringComparison.InvariantCulture)}",
                           request.Uri.AbsoluteUri);
        }

        [Fact]
        public void GetRandomPhotoRequest_UsernameAndQueryWithoutSpaces_ProducesAnExpectedURI()
        {
            var orientation = Orientation.PORTRAIT;
            var collections = new[] { "1", "2" };
            var featured = true;
            var username = "AB";
            var query = "CD";
            var request = new GetRandomPhotoRequest(orientation,
                                                    collections,
                                                    featured,
                                                    username,
                                                    query);
            Assert.Matches($"&orientation={orientation.Describe()}" +
                           $"&collections={collections.Join()}" +
                           $"&featured={featured}" +
                           $"&username={username}" +
                           $"&query={query}",
                           request.Uri.AbsoluteUri);
        }
    }
}
