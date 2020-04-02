// <copyright file="GetRandomPhotosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Unsplash.Photos;

    public class GetRandomPhotosRequest : GetRandomPhotoRequest
    {
        public GetRandomPhotosRequest(uint count,
                                      Orientation? orientation = null,
                                      string[]? collections = null,
                                      bool? featured = null,
                                      string? username = null,
                                      string? query = null)
            : base(orientation, collections, featured, username, query) =>
            Count = count;

        public GetRandomPhotosRequest() => Count = 10;

        public override Uri Uri
        {
            get
            {
                var address = base.Uri.AbsoluteUri;
                address += $"&count={Count}";
                return new Uri(address);
            }
        }

        protected uint Count { get; }
    }
}
