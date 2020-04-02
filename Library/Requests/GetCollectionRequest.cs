// <copyright file="GetCollectionRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;

    public class GetCollectionRequest : Request
    {
        public GetCollectionRequest(string id) =>
            Id = id;

        public override Uri Uri => new Uri($"{BaseUrl}collections/{Id}?client_id={AccessKey}");

        private string Id { get; }
    }
}
