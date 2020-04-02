// <copyright file="CollectionTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Collections
{
    using System;
    using global::Unsplash.Collections;
    using global::Unsplash.Photos;
    using global::Unsplash.Users;
    using Xunit;
    using CollectionLinks = global::Unsplash.Collections.Links;

    public class CollectionTest
    {
        [Fact]
        public void ToString_FeaturedCollection_ReturnsASummary()
        {
            var collection = new Collection()
            {
                id = 1,
                title = "Collection",
                description = "A Collection",
                published_at = DateTime.Now,
                featured = true,
                total_photos = 1,
                cover_photo = new Photo(),
                user = new User()
                {
                    first_name = "A",
                    last_name = "B",
                },
                links = new CollectionLinks()
                {
                    self = new Uri("http://a.b.c"),
                    html = new Uri("http://a.b.c"),
                    photos = new Uri("http://a.b.c"),
                    related = new Uri("http://a.b.c"),
                },
            };
            string summary = collection.ToString();
            Assert.Equal($"Id: 1\n" +
                         $"Title: Collection\n" +
                         $"Description: A Collection\n" +
                         $"Published At: {DateTime.Now}\n" +
                         $"Featured: Yes\n" +
                         $"Total Photos: 1\n" +
                         $"Author: A B", summary);
        }

        [Fact]
        public void ToString_NotFeaturedCollection_ReturnsASummary()
        {
            var collection = new Collection()
            {
                id = 1,
                title = "Collection",
                description = "A Collection",
                published_at = DateTime.Now,
                featured = false,
                total_photos = 1,
                cover_photo = new Photo(),
                user = new User()
                {
                    first_name = "A",
                    last_name = "B",
                },
                links = new CollectionLinks()
                {
                    self = new Uri("http://a.b.c"),
                    html = new Uri("http://a.b.c"),
                    photos = new Uri("http://a.b.c"),
                    related = new Uri("http://a.b.c"),
                },
            };
            string description = collection.ToString();
            Assert.Equal($"Id: 1\n" +
                         $"Title: Collection\n" +
                         $"Description: A Collection\n" +
                         $"Published At: {DateTime.Now}\n" +
                         $"Featured: No\n" +
                         $"Total Photos: 1\n" +
                         $"Author: A B", description);
        }
    }
}
