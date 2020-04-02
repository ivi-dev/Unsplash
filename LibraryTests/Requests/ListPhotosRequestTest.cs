// <copyright file="ListPhotosRequestTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Requests
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Xunit;

    public class ListPhotosRequestTest
    {
        [Fact]
        public void ListPhotosRequest_Arguments_ProducesAnExpectedURI()
        {
            var order = Order.POPULAR;
            uint page = 2;
            uint perPage = 15;
            var request = new ListPhotosRequest(order, page, perPage);
            Assert.Matches($"&order={order.Describe()}&page={page}&per_page={perPage}",
                           request.Uri.AbsoluteUri);
        }
    }
}
