// <copyright file="GetRandomPhotoRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class GetRandomPhotoRequest : Request
    {
        public GetRandomPhotoRequest(Orientation? orientation = null,
                                     string[]? collections = null,
                                     bool? featured = null,
                                     string? username = null,
                                     string? query = null) =>
            (Orientation, Collections, Featured, Username, Query) =
            (orientation.Describe(), collections.Join(), featured, username, query);

        public GetRandomPhotoRequest()
        {
        }

        public string? Orientation { get; }

        public string? Collections { get; }

        public bool? Featured { get; }

        public string? Username { get; }

        public string? Query { get; }

        public override Uri Uri
        {
            get
            {
                var address = $"{BaseUrl}photos/random?client_id={AccessKey}";
                if (Orientation != null)
                    address += $"&orientation={Orientation}";
                if (Collections != null)
                    address += $"&collections={Collections}";
                if (Featured != null)
                    address += $"&featured={Featured}";
                if (Username != null)
                    address += $"&username={Username}";
                if (Query != null)
                    address += $"&query={Query}";
                return new Uri(address);
            }
        }
    }
}
