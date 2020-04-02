// <copyright file="Collection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Collections
{
    using System;
    using Unsplash.Photos;
    using Unsplash.Users;

    public class Collection
    {
        public uint id { get; set; }

        public string title { get; set; }

        public string? description { get; set; }

        public DateTime published_at { get; set; }

        public bool featured { get; set; }

        public uint total_photos { get; set; }

        public Photo cover_photo { get; set; }

        public User user { get; set; }

        public Links links { get; set; }

        public override string ToString()
        {
            var info = $"Id: {id}\n" +
                       $"Title: {title}\n" +
                       $"Description: {description}\n" +
                       $"Published At: {published_at}\n" +
                       $"Featured: {IsFeatured()}\n" +
                       $"Total Photos: {total_photos}\n" +
                       $"Author: {user.first_name} {user.last_name}";
            return info;
        }

        private string IsFeatured()
        {
            return featured ? "Yes" : "No";
        }
    }
}
