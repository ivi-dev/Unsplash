// <copyright file="ListRelatedCollectionsRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class ListRelatedCollectionsRequestTest
    {
        [Fact]
        public void ListRelatedCollectionsRequest_Id_ProducesAnExpectedURI()
        {
            var id = "abc";
            var request = new ListRelatedCollectionsRequest(id);
            Assert.Matches($"/{id}", request.Uri.AbsoluteUri);
        }
    }
}
