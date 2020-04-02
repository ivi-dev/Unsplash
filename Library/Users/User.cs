// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Users
{
    using System;

    public class User
    {
        public string id { get; set; }

        public Links links { get; set; }

        public uint total_collections { get; set; } = 0;

        public uint total_likes { get; set; } = 0;

        public uint total_photos { get; set; } = 0;

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public Uri? portfolio_url { get; set; }

        public string? bio { get; set; }

        public string? location { get; set; }

        public ProfileImage? profile_image { get; set; }
    }
}
