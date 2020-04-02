// <copyright file="TrackPhotoDownloadRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class TrackPhotoDownloadRequestTest
    {
        [Fact]
        public void TrackPhotoDownloadRequest_Id_ProducesAnExpectedURI()
        {
            var id = "123";

            var request = new TrackPhotoDownloadRequest(id);
            Assert.Matches($"/{id}", request.Uri.AbsoluteUri);
        }
    }
}
