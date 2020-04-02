// <copyright file="PhotoTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Photos
{
    using System;
    using global::Unsplash.Photos;
    using global::Unsplash.Users;
    using Xunit;

    public class PhotoTest
    {
        [Fact]
        public void ToString_Photo_ReturnsASummary()
        {
            var photo = new Photo()
            {
                id = "1",
                created_at = DateTime.Now,
                user = new User()
                {
                    first_name = "A",
                    last_name = "B",
                },
                width = 200,
                height = 100,
                color = "#fff",
                description = "Photo",
                alt_description = "a",
            };
            var summary = photo.ToString();
            Assert.Equal($"Id: 1\n" +
                         $"Created At: {DateTime.Now}\n" +
                         $"Author: A B\n" +
                         $"Size: 200x100 pixels\n" +
                         $"Color: #fff\n" +
                         $"Description: Photo a", summary);
        }
    }
}
