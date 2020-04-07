// <copyright file="Defaults.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Library
{
    using System;
    using Unsplash.Photos;

    public static class Defaults
    {
        public static uint PerPage { get; } = 10;

        public static uint PerPageMax { get; } = 30;

        public static uint Page { get; } = 1;

        public static Order Order { get; } = Order.LATEST;
    }
}
