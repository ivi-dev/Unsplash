// <copyright file="RequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class RequestTest
    {
        [Fact]
        public void GetDefaultRequest_ListPhotosRequest_ReturnsAnInstanceOfListPhotosRequest()
        {
            var request = Request.GetDefaultRequest<ListPhotosRequest>();
            Assert.IsType<ListPhotosRequest>(request);
        }

        [Fact]
        public void GetDefaultRequest_ListFeaturedCollectionsRequest_ReturnsAnInstanceOfListFeaturedCollectionsRequest()
        {
            var request = Request.GetDefaultRequest<ListFeaturedCollectionsRequest>();
            Assert.IsType<ListFeaturedCollectionsRequest>(request);
        }

        [Fact]
        public void GetDefaultRequest_ListRelatedCollectionsRequest_ReturnsAnInstanceOfListRelatedCollectionsRequest()
        {
            var request = Request.GetDefaultRequest<ListRelatedCollectionsRequest>();
            Assert.IsType<ListRelatedCollectionsRequest>(request);
        }
    }
}
