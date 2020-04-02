// <copyright file="EnumExtensionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Extensions
{
    using global::Unsplash.Extensions;
    using global::Unsplash.Photos;
    using Xunit;

    public class EnumExtensionsTest
    {
        [Fact]
        public void Describe_ColorFilterBlack_ReturnsAnEnumsStringValueWithNoUnderscoresLowercased()
        {
            var filter = ColorFilter.BLACK;
            string? description = filter.Describe();
            Assert.Equal("black", description);
        }

        [Fact]
        public void Describe_ColorFilterBlackAndWhite_ReturnsAnEnumsStringValueWithUnderscoresLowercased()
        {
            var filter = ColorFilter.BLACK_AND_WHITE;
            string? description = filter.Describe();
            Assert.Equal("black_and_white", description);
        }

        [Fact]
        public void Describe_Null_ReturnsNull()
        {
            ColorFilter? filter = null;
            string? description = filter.Describe();
            Assert.Null(description);
        }
    }
}
