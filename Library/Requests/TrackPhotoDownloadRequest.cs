// <copyright file="TrackPhotoDownloadRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;

    public class TrackPhotoDownloadRequest : Request
    {
        public TrackPhotoDownloadRequest(string id) =>
            Id = id;

        public override Uri Uri => new Uri($"{BaseUrl}photos/{Id}/download?client_id={AccessKey}");

        private string Id { get; }
    }
}
