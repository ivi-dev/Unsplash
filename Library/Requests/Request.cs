// <copyright file="Request.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Requests
{
    using System;

    public abstract class Request
    {
        public abstract Uri Uri { get; }

        protected Uri BaseUrl { get; } = Client.BaseAddress;

        protected string AccessKey { get; } = Client.AccessKey;

        public static T GetDefaultRequest<T>()
            where T : new()
            => new T();
    }
}
