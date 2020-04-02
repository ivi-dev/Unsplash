// <copyright file="StringExtensionsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Extensions
{
    using System;
    using global::Unsplash.Extensions;
    using Xunit;

    public class StringExtensionsTest
    {
        [Fact]
        public void ToByteArray_String_ReturnsAnArrayOfBytesRepresentingTheString()
        {
            var str = "ab";
            var bytes = str.ToByteArray();
            Assert.Equal(new byte[] { 97, 98 }, bytes);
        }

        [Fact]
        public void ToByteArray_Null_ThrowsArgumentNullException()
        {
            string? str = null;
            Assert.Throws<ArgumentNullException>(() => str.ToByteArray());
        }
    }
}
