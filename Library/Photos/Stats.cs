// <copyright file="Stats.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Photos
{
    public class Stats
    {
        public Downloads downloads { get; set; }

        public override string ToString()
        {
            var stats = $"Total Downloads: {downloads.total}";
            return stats;
        }
    }
}
