// <copyright file="GetPhotoRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;

    public class GetPhotoRequest : Request
    {
        public GetPhotoRequest(string id) =>
            Id = id;

        public override Uri Uri => new Uri($"{BaseUrl}photos/{Id}?client_id={AccessKey}");

        private string Id { get; }
    }
}
