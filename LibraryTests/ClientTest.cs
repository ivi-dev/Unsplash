// <copyright file="ClientTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.Unsplash
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::Unsplash;
    using global::Unsplash.Collections;
    using global::Unsplash.Photos;
    using global::Unsplash.Requests;
    using Pose;
    using UnsplashTests.TestUtilities;
    using Xunit;
    using CollectionsSearchResults = global::Unsplash.Collections.SearchResults;
    using PhotosSearchResults = global::Unsplash.Photos.SearchResults;

    public sealed class ClientTest : IDisposable
    {
        private readonly Client client = new Client(string.Empty);

        [Fact]
        public async Task ListPhotosAsync_Null_ReturnsAListOfPhotos()
        {
            List<Photo> expected = ClientTestUtilities.ShimGetAsync<ListPhotosRequest, List<Photo>>();
            PoseContext.Isolate(async () =>
            {
                List<Photo> list = await client.ListPhotosAsync().ConfigureAwait(false);
                Assert.Equal(list[0], expected[0]);
            });
        }

        [Fact]
        public async Task GetPhotoAsync_Id_ReturnsAPhoto()
        {
            Photo expected = ClientTestUtilities.ShimGetAsync<GetPhotoRequest, Photo>();
            PoseContext.Isolate(async () =>
            {
                Photo photo = await client.GetPhotoAsync("1").ConfigureAwait(false);
                Assert.Equal(photo, expected);
            });
        }

        [Fact]
        public async Task GetRandomPhotoAsync_Null_ReturnsAPhoto()
        {
            Photo expected = ClientTestUtilities.ShimGetAsync<GetPhotoRequest, Photo>();
            PoseContext.Isolate(async () =>
            {
                Photo photo = await client.GetRandomPhotoAsync().ConfigureAwait(false);
                Assert.Equal(photo, expected);
            });
        }

        [Fact]
        public async Task GetRandomPhotosAsync_Null_ReturnsAListOfPhotos()
        {
            List<Photo> expected = ClientTestUtilities.ShimGetAsync<GetRandomPhotosRequest, List<Photo>>();
            PoseContext.Isolate(async () =>
            {
                List<Photo> photos = await client.GetRandomPhotosAsync().ConfigureAwait(false);
                Assert.Equal(photos[0], expected[0]);
            });
        }

        [Fact]
        public async Task GetPhotoStatsAsync_Id_ReturnsStats()
        {
            Stats expected = ClientTestUtilities.ShimGetAsync<GetPhotoStatsRequest, Stats>();
            PoseContext.Isolate(async () =>
            {
                Stats stats = await client.GetPhotoStatsAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(stats, expected);
            });
        }

        [Fact]
        public async Task SearchPhotosAsync_Query_ReturnsSearchResults()
        {
            PhotosSearchResults expected = ClientTestUtilities.ShimGetAsync<SearchPhotosRequest, PhotosSearchResults>();
            PoseContext.Isolate(async () =>
            {
                PhotosSearchResults results = await client.SearchPhotosAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(results, expected);
            });
        }

        [Fact]
        public async Task DownloadPhotoAsync_UrlIdDestination_ReturnsTheSizeOfTheDownloadedFile()
        {
            var buffer = new byte[] { 1, 2 };
            ClientTestUtilities.ShimGetByteArrayAsync(buffer);
            ClientTestUtilities.ShimFileCreate();
            ClientTestUtilities.ShimGetAsync<DownloadPhotoRequest, PhotoDownloadMarker>();
            PoseContext.Isolate(async () =>
            {
                long fileSize = await client.DownloadPhotoAsync(new Uri("http://a.b.c"), "1", @"C:\1.jpg").ConfigureAwait(false);
                Assert.Equal(buffer.Length, fileSize);
            });
        }

        [Fact]
        public async Task SearchCollectionsAsync_Query_ReturnsSearchResults()
        {
            CollectionsSearchResults expected = ClientTestUtilities.ShimGetAsync<SearchCollectionsRequest, CollectionsSearchResults>();
            PoseContext.Isolate(async () =>
            {
                CollectionsSearchResults result = await client.SearchCollectionsAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(result, expected);
            });
        }

        [Fact]
        public async Task ListFeaturedCollectionsAsync_Null_ReturnsAListOfCollections()
        {
            List<Collection> expected = ClientTestUtilities.ShimGetAsync<ListFeaturedCollectionsRequest, List<Collection>>();
            PoseContext.Isolate(async () =>
            {
                List<Collection> result = await client.ListFeaturedCollectionsAsync().ConfigureAwait(false);
                Assert.Equal(result, expected);
            });
        }

        [Fact]
        public async Task GetCollectionAsync_Null_ReturnsACollection()
        {
            Collection expected = ClientTestUtilities.ShimGetAsync<GetCollectionRequest, Collection>();
            PoseContext.Isolate(async () =>
            {
                Collection result = await client.GetCollectionAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(result, expected);
            });
        }

        [Fact]
        public async Task GetCollectionPhotosAsync_Id_ReturnsACollection()
        {
            List<Photo> expected = ClientTestUtilities.ShimGetAsync<GetCollectionPhotosRequest, List<Photo>>();
            PoseContext.Isolate(async () =>
            {
                List<Photo> result = await client.GetCollectionPhotosAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(result, expected);
            });
        }

        [Fact]
        public async Task ListRelatedCollectionsAsync_Id_ReturnsACollection()
        {
            List<Collection> expected = ClientTestUtilities.ShimGetAsync<ListRelatedCollectionsRequest, List<Collection>>();
            PoseContext.Isolate(async () =>
            {
                List<Collection> result = await client.ListRelatedCollectionsAsync(string.Empty).ConfigureAwait(false);
                Assert.Equal(result, expected);
            });
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
