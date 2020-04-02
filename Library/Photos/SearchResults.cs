// <copyright file="SearchResults.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Photos
{
    using System.Collections.Generic;

    public class SearchResults
    {
        public List<Photo> results { get; set; }

        public uint total { get; set; }

        public uint total_pages { get; set; }
    }
}
