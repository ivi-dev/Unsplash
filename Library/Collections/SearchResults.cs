// <copyright file="SearchResults.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Collections
{
    using System.Collections.Generic;

    public class SearchResults
    {
        public List<Collection> results { get; set; }

        public uint total { get; set; }

        public uint total_pages { get; set; }
    }
}
