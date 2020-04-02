// <copyright file="ArrayExtensionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Extensions
{
    using System;
    using global::Unsplash.Extensions;
    using Xunit;

    public class ArrayExtensionsTest
    {
        [Fact]
        public void Join_ArrayWithTwoElements_ReturnsTheTwoElementsJoinedByTheDefaultJoiningCharacter()
        {
            var array = new string[] { "a", "b" };
            string? result = array.Join();
            Assert.Equal("a,b", result);
        }

        [Fact]
        public void Join_ArrayWithTwoElements_ReturnsTheTwoElementsJoinedByAnExplicitJoiningCharacter()
        {
            var array = new string[] { "a", "b" };
            string? result = array.Join(".");
            Assert.Equal("a.b", result);
        }

        [Fact]
        public void Join_AnEmptyArray_ThrowsAnArgumentException()
        {
            var array = Array.Empty<string>();
            void Join() => array.Join();
            Assert.Throws<ArgumentException>(Join);
        }

        [Fact]
        public void Join_Null_ReturnsNull()
        {
            string[]? array = null;
            string? result = array.Join();
            Assert.Null(result);
        }
    }
}
