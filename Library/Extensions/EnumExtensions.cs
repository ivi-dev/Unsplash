// <copyright file="EnumExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Extensions
{
    using System;

    public static class EnumExtensions
    {
        public static string? Describe(this Enum? e)
        {
            return e?.ToString().ToLowerInvariant();
        }
    }
}
