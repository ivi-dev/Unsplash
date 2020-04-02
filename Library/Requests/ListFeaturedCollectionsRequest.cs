// <copyright file="ListFeaturedCollectionsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;

    public class ListFeaturedCollectionsRequest : Request
    {
        public ListFeaturedCollectionsRequest(uint? page = null,
                                              uint? perPage = null) =>
            (Page, PerPage) = (page, perPage);

        public ListFeaturedCollectionsRequest()
        {
        }

        public override Uri Uri
        {
            get
            {
                string address = $"{BaseUrl}collections/featured?client_id={AccessKey}";
                if (Page != null)
                    address += $"&page={Page}";
                if (PerPage != null)
                    address += $"&per_page={PerPage}";
                return new Uri(address);
            }
        }

        private uint? Page { get; }

        private uint? PerPage { get; }
    }
}