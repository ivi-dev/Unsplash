// <copyright file="GetPhotoStatsRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

#nullable disable warnings
namespace Unsplash.Requests
{
    using System;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class GetPhotoStatsRequest : Request
    {
        public GetPhotoStatsRequest(string id,
                                    StatsResolution? resolution = null,
                                    uint? quantity = null) =>
            (Id, Resolution, Quantity) = (id, resolution.Describe(), quantity);

        public GetPhotoStatsRequest()
        {
        }

        public override Uri Uri
        {
            get
            {
                var address = $"{BaseUrl}photos/{Id}/statistics?client_id={AccessKey}";
                if (Resolution != null)
                {
                    address += $"&resolution={Resolution}";
                }

                if (Quantity != null)
                {
                    address += $"&quantity={Quantity}";
                }

                return new Uri(address);
            }
        }

        private string Id { get; }

        private string? Resolution { get; }

        private uint? Quantity { get; }
    }
}
