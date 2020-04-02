// <copyright file="ListRelatedCollectionsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Requests
{
    using System;

    public class ListRelatedCollectionsRequest : Request
    {
        public ListRelatedCollectionsRequest(string id) => Id = id;

        public ListRelatedCollectionsRequest()
        {
        }

        public string Id { get; }

        public override Uri Uri => new Uri($"{BaseUrl}collections/{Id}/related?client_id={AccessKey}");
    }
}