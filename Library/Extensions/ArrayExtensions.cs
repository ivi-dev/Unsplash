// <copyright file="ArrayExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Extensions
{
    using System;
    using System.Text;

    public static class ArrayExtensions
    {
        public static string? Join(this string[]? array, string separator = ",")
        {
            if (array == null)
                return null;
            if (array.Length.Equals(0))
                throw new ArgumentException(null, nameof(array));
            var joined = new StringBuilder((array.Length * 2) - 1);
            return joined.AppendJoin(separator, array).ToString();
        }
    }
}
