// <copyright file="StatsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Photos
{
    using global::Unsplash.Photos;
    using Xunit;

    public class StatsTest
    {
        [Fact]
        public void ToString_Stats_ReturnsASummary()
        {
            var stats = new Stats()
            {
                downloads = new Downloads()
                {
                    total = 1,
                },
            };
            string summary = stats.ToString();
            Assert.Equal($"Total Downloads: 1", summary);
        }
    }
}
