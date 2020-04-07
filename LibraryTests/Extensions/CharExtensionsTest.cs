// <copyright file="CharExtensionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Extensions
{
    using System;
    using global::Unsplash.Extensions;
    using Xunit;

    public class CharExtensionsTest
    {
        [Fact]
        public void IsHyphenOrUnderscore_Hyphen_ReturnsTrue()
        {
            var character = '-';
            bool result = character.IsHyphenOrUnderscore();
            Assert.True(result);
        }

        [Fact]
        public void IsHyphenOrUnderscore_Underscore_ReturnsTrue()
        {
            var character = '_';
            bool result = character.IsHyphenOrUnderscore();
            Assert.True(result);
        }

        [Fact]
        public void IsHyphenOrUnderscore_Letter_ReturnsFalse()
        {
            var character = 'a';
            bool result = character.IsHyphenOrUnderscore();
            Assert.False(result);
        }
    }
}
