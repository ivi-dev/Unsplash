// <copyright file="GetRandomPhotosRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class GetRandomPhotosRequestTest
    {
        [Fact]
        public void GetRandomPhotosRequest_CountArgumentOnly_ProducesAnExpectedURI()
        {
            uint count = 10;
            var request = new GetRandomPhotosRequest(count);
            Assert.Matches($"&count={count}", request.Uri.AbsoluteUri);
        }
    }
}
