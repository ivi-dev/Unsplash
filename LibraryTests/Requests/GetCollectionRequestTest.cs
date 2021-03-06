﻿// <copyright file="GetCollectionRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Requests;
    using Xunit;

    public class GetCollectionRequestTest
    {
        [Fact]
        public void GetCollectionRequest_Id_ProducesAnExpectedURI()
        {
            var id = "123";

            var request = new GetCollectionRequest(id);
            Assert.Matches($"{id}", request.Uri.AbsoluteUri);
        }
    }
}
