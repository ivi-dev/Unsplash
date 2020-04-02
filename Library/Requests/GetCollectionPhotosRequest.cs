// <copyright file="GetCollectionPhotosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class GetCollectionPhotosRequest : Request
    {
        public GetCollectionPhotosRequest(string id,
                                          uint? page = null,
                                          uint? perPage = null,
                                          Orientation? orientation = null) =>
            (Id, Page, PerPage, Orientation) = (id, page, perPage, orientation.Describe());

        public override Uri Uri
        {
            get
            {
                var address = $"{BaseUrl}collections/{Id}/photos?client_id={AccessKey}";
                if (Page != null)
                    address += $"&page={Page}";
                if (PerPage != null)
                    address += $"&per_page={PerPage}";
                if (Orientation != null)
                    address += $"&orientation={Orientation}";
                return new Uri(address);
            }
        }

        private string Id { get; }

        private uint? Page { get; }

        private uint? PerPage { get; }

        private string? Orientation { get; }
    }
}