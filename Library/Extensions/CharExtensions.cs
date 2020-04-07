// <copyright file="CharExtensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Extensions
{
    public static class CharExtensions
    {
        public static bool IsHyphenOrUnderscore(this char c)
        {
            return c.Equals('-') || c.Equals('_');
        }
    }
}
