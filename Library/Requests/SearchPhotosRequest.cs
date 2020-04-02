// <copyright file="SearchPhotosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class SearchPhotosRequest : Request
    {
        public SearchPhotosRequest(string query,
                                   uint? page = null,
                                   uint? perPage = null,
                                   Sort? sort = null,
                                   string[]? collections = null,
                                   ColorFilter? color = null,
                                   Orientation? orientation = null) =>
            (Query, Page, PerPage, Sort, Collections, Color, Orientation) =
            (query, page, perPage, sort.Describe(), collections, color.Describe(), orientation.Describe());

        public override Uri Uri
        {
            get
            {
                var address = $"{BaseUrl}search/photos?client_id={AccessKey}";
                if (Query != null)
                    address += $"&query={Query}";
                if (Page != null)
                    address += $"&page={Page}";
                if (PerPage != null)
                    address += $"&per_page={PerPage}";
                if (Sort != null)
                    address += $"&order_by={Sort}";
                if (Collections != null)
                    address += $"&collections={Collections.Join()}";
                if (Color != null)
                    address += $"&color={Color}";
                if (Orientation != null)
                    address += $"&orientation={Orientation}";
                return new Uri(address);
            }
        }

        private string Query { get; }

        private uint? Page { get; }

        private uint? PerPage { get; }

        private string? Sort { get; }

        private string[]? Collections { get; }

        private string? Color { get; }

        private string? Orientation { get; }
    }
}