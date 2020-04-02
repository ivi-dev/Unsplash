// <copyright file="TestUtilitiesTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.TestUtilities
{
    using System;
    using System.Collections.Generic;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Pose;
    using Xunit;

    public class TestUtilitiesTest
    {
        [Fact]
        public void Deserialize_String_ReturnsAnExpectedObject()
        {
            var result = ClientTestUtilities.Deserialize<Photo>(ClientTestUtilities.RawPhoto);
            PoseContext.Isolate(() =>
            {
                Assert.IsType<Photo>(result);
            });
        }

        [Fact]
        public void ShimGetAsync_NoArguments_ReturnsAnExpectedType()
        {
            var result = ClientTestUtilities.ShimGetAsync<ListPhotosRequest, List<Photo>>();
            PoseContext.Isolate(() =>
            {
                Assert.IsType<List<Photo>>(result);
            });
        }

        [Fact]
        public void ShimGetByteArrayAsync_Buffer_ReturnsAShim()
        {
            var buffer = new byte[] { 1, 2 };
            Shim result = ClientTestUtilities.ShimGetByteArrayAsync(buffer);
            PoseContext.Isolate(() =>
            {
                Assert.IsType<Shim>(result);
            });
        }

        [Fact]
        public void ShimFileCreate_NoArguments_ReturnsAShim()
        {
            Shim result = ClientTestUtilities.ShimFileCreate();
            PoseContext.Isolate(() =>
            {
                Assert.IsType<Shim>(result);
            });
        }

        [Fact]
        public void MockHttpResponse_NullTRequest_ThrowsAnException()
        {
            static void Action() => ClientTestUtilities.MockHttpResponse<Request, Photo>();
            Assert.Throws<Exception>(Action);
        }
    }
}
