// <copyright file="DownloadPhotoRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash.Requests
{
    using System;
    using Unsplash.Extensions;
    using Unsplash.Photos;

    public class DownloadPhotoRequest : Request
    {
        public DownloadPhotoRequest(Uri baseUrl,
                                    uint? width = null,
                                    uint? height = null,
                                    Crop? crop = null,
                                    Format? format = null,
                                    uint? quality = null,
                                    Fit? fit = null,
                                    uint? dpi = null) =>
            (BaseUrl, Width, Height, Crop, Format, Quality, Fit, Dpi) =
            (baseUrl, width, height, crop.Describe(), format.Describe(), quality, fit.Describe(), dpi);

        public new Uri BaseUrl { get; }

        public uint? Width { get; }

        public uint? Height { get; }

        public string? Crop { get; }

        public string? Format { get; }

        public uint? Quality { get; }

        public string? Fit { get; }

        public uint? Dpi { get; }

        public override Uri Uri
        {
            get
            {
                var address = BaseUrl.AbsoluteUri;
                if (Width != null)
                    address += $"&w={Width}";
                if (Height != null)
                    address += $"&h={Height}";
                if (Crop != null)
                    address += $"&crop={Crop}";
                if (Format != null)
                    address += $"&fm={Format}";
                if (Quality != null)
                    address += $"&q={Quality}";
                if (Fit != null)
                    address += $"&fit={Fit}";
                if (Dpi != null)
                    address += $"&dpi={Dpi}";
                return new Uri(address);
            }
        }
    }
}
