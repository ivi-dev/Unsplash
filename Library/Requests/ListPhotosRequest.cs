// <copyright file="ListPhotosRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Library;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class ListPhotosRequest : Request
    {
        private readonly uint? perPage;

        public ListPhotosRequest(Order? order = null,
                                 uint? page = null,
                                 uint? perPage = null) =>
            (Order, Page, this.perPage) = (order.Describe(), page, perPage);

        public ListPhotosRequest()
        {
        }

        public override Uri Uri
        {
            get
            {
                string address = $"{BaseUrl}photos?client_id={AccessKey}";
                if (Order != null)
                    address += $"&order={Order}";
                if (Page != null)
                    address += $"&page={Page}";
                if (PerPage != null)
                    address += $"&per_page={PerPage}";
                return new Uri(address);
            }
        }

        private string? Order { get; }

        private uint? Page { get; }

        private uint? PerPage
        {
            get
            {
                if (perPage != null)
                    return perPage < Defaults.PerPageMax ? perPage : Defaults.PerPageMax;
                return null;
            }
        }
    }
}
