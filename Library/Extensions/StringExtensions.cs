// <copyright file="StringExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Extensions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public static class StringExtensions
    {
        public static byte[] ToByteArray([AllowNull] this string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            var bytes = new byte[s.Length];
            for (var i = 0; i < s.Length; i++)
            {
                bytes[i] = Convert.ToByte(s[i]);
            }

            return bytes;
        }
    }
}
