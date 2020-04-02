// <copyright file="SearchCollectionsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;

    public class SearchCollectionsRequest : Request
    {
        public SearchCollectionsRequest(string query,
                                        uint? page = null,
                                        uint? perPage = null) =>
            (Query, Page, PerPage) = (query, page, perPage);

        public override Uri Uri
        {
            get
            {
                var address = $"{BaseUrl}search/collections?client_id={AccessKey}";
                if (Query != null)
                    address += $"&query={Query}";
                if (Page != null)
                    address += $"&page={Page}";
                if (PerPage != null)
                    address += $"&per_page={PerPage}";
                return new Uri(address);
            }
        }

        private string Query { get; }

        private uint? Page { get; }

        private uint? PerPage { get; }
    }
}