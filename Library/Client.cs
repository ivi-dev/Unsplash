// <copyright file="Client.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Unsplash
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Unsplash.Collections;
    using Unsplash.Extensions;
    using Unsplash.Photos;
    using Unsplash.Requests;

    public sealed class Client : IDisposable
    {
        private const string VERSION = "1";
        private readonly HttpClient netClient = new HttpClient();

        public Client(string accessKey)
        {
            AccessKey = accessKey;
            netClient.DefaultRequestHeaders.Add("Accept-Version", $"v{VERSION}");
        }

        internal static Uri BaseAddress { get; } = new Uri("https://api.unsplash.com/");

        internal static string AccessKey { get; private set; } = string.Empty;

        public void Dispose()
        {
            netClient.Dispose();
        }

        public async Task<List<Photo>> ListPhotosAsync(ListPhotosRequest? request = null)
        {
            var uri = request == null ? Request.GetDefaultRequest<ListPhotosRequest>().Uri : request.Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Photo>>(response).ConfigureAwait(false);
        }

        public async Task<Photo> GetPhotoAsync(string id)
        {
            var uri = new GetPhotoRequest(id).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Photo>(response).ConfigureAwait(false);
        }

        public async Task<Photo> GetRandomPhotoAsync(GetRandomPhotoRequest? request = null)
        {
            var uri = request == null ? Request.GetDefaultRequest<GetRandomPhotoRequest>().Uri : request.Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Photo>(response).ConfigureAwait(false);
        }

        public async Task<List<Photo>> GetRandomPhotosAsync(uint count)
        {
            var uri = new GetRandomPhotosRequest(count).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Photo>>(response).ConfigureAwait(false);
        }

        public async Task<List<Photo>> GetRandomPhotosAsync(GetRandomPhotosRequest? request = null)
        {
            var uri = request == null ? Request.GetDefaultRequest<GetRandomPhotosRequest>().Uri : request.Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Photo>>(response).ConfigureAwait(false);
        }

        public async Task<Stats> GetPhotoStatsAsync(string id)
        {
            var uri = new GetPhotoStatsRequest(id).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Stats>(response).ConfigureAwait(false);
        }

        public async Task<Stats> GetPhotoStatsAsync(GetPhotoStatsRequest request)
        {
            var uri = request == null ? Request.GetDefaultRequest<GetPhotoStatsRequest>().Uri : request.Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Stats>(response).ConfigureAwait(false);
        }

        public async Task<Photos.SearchResults> SearchPhotosAsync(string query)
        {
            string encoded = WebUtility.UrlEncode(query);
            var uri = new SearchPhotosRequest(encoded).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Photos.SearchResults>(response).ConfigureAwait(false);
        }

        public async Task<Photos.SearchResults> SearchPhotosAsync(SearchPhotosRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            HttpResponseMessage response = await netClient.GetAsync(request.Uri).ConfigureAwait(false);
            return await ParseResponseAsync<Photos.SearchResults>(response).ConfigureAwait(false);
        }

        public async Task<long> DownloadPhotoAsync(Uri url, string id, string destination)
        {
            var uri = new DownloadPhotoRequest(url).Uri;
            var bytes = await netClient.GetByteArrayAsync(uri).ConfigureAwait(false);
            long fileSize = StoreFile(destination, bytes);
            await RecordPhotoDownloadAsync(id).ConfigureAwait(false);
            return fileSize;
        }

        public async Task<long> DownloadPhotoAsync(DownloadPhotoRequest request,
                                                                 string id,
                                                                 string destination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            var bytes = await netClient.GetByteArrayAsync(request.Uri).ConfigureAwait(false);
            long fileSize = StoreFile(destination, bytes);
            await RecordPhotoDownloadAsync(id).ConfigureAwait(false);
            return fileSize;
        }

        public async Task<Collections.SearchResults> SearchCollectionsAsync(string query)
        {
            var uri = new SearchCollectionsRequest(query).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Collections.SearchResults>(response).ConfigureAwait(false);
        }

        public async Task<Collections.SearchResults> SearchCollectionsAsync(SearchCollectionsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            HttpResponseMessage response = await netClient.GetAsync(request.Uri).ConfigureAwait(false);
            return await ParseResponseAsync<Collections.SearchResults>(response).ConfigureAwait(false);
        }

        public async Task<List<Collection>> ListFeaturedCollectionsAsync(ListFeaturedCollectionsRequest? request = null)
        {
            var uri = request == null ? Request.GetDefaultRequest<ListFeaturedCollectionsRequest>().Uri : request.Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Collection>>(response).ConfigureAwait(false);
        }

        public async Task<Collection> GetCollectionAsync(string id)
        {
            var uri = new GetCollectionRequest(id).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<Collection>(response).ConfigureAwait(false);
        }

        public async Task<List<Photo>> GetCollectionPhotosAsync(string id)
        {
            var uri = new GetCollectionPhotosRequest(id).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Photo>>(response).ConfigureAwait(false);
        }

        public async Task<List<Photo>> GetCollectionPhotosAsync(GetCollectionPhotosRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            HttpResponseMessage response = await netClient.GetAsync(request.Uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Photo>>(response).ConfigureAwait(false);
        }

        public async Task<List<Collection>> ListRelatedCollectionsAsync(string id)
        {
            var uri = new ListRelatedCollectionsRequest(id).Uri;
            HttpResponseMessage response = await netClient.GetAsync(uri).ConfigureAwait(false);
            return await ParseResponseAsync<List<Collection>>(response).ConfigureAwait(false);
        }

        private static long StoreFile(string path, byte[] buffer)
        {
            using var stream = File.Create(path);
            using var writer = new BinaryWriter(stream);
            writer.Write(buffer);
            long bytes = writer.BaseStream.Length;
            return bytes;
        }

        private async Task<T> ParseResponseAsync<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var bytes = content.ToByteArray();
            return (T)JsonSerializer.Deserialize(new ReadOnlySpan<byte>(bytes), typeof(T));
        }

        private async Task RecordPhotoDownloadAsync(string id)
        {
            var parameters = new TrackPhotoDownloadRequest(id);
            await netClient.GetAsync(parameters.Uri).ConfigureAwait(false);
        }
    }
}
