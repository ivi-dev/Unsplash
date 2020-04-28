// <copyright file="Photo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Photos
{
    using System;
    using Unsplash.Users;

    public class Photo
    {
        public string id { get; set; }

        public DateTime created_at { get; set; }

        public User user { get; set; }

        public uint width { get; set; }

        public uint height { get; set; }

        public URLs urls { get; set; }

        public uint likes { get; set; }

        public string? color { get; set; }

        public string? description { get; set; }

        public string? alt_description { get; set; }

        public override string ToString()
        {
            var info = $"Id: {id}\n" +
                       $"Created At: {created_at}\n" +
                       $"Author: {user.first_name} {user.last_name}\n" +
                       $"Size: {width}x{height} pixels\n" +
                       $"Color: {color}\n" +
                       $"Description: {description} {alt_description}";
            return info;
        }
    }
}
