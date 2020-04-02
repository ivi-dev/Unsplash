// <copyright file="GetPhotoRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class GetPhotoRequestTest
    {
        [Fact]
        public void GetPhotoRequest_Arguments_ProducesAnExpectedURI()
        {
            var id = "123";
            var request = new GetPhotoRequest(id);
            Assert.Matches($"/{id}", request.Uri.AbsoluteUri);
        }
    }
}
