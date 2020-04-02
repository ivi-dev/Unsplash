// <copyright file="ClientTestUtilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnsplashTests.TestUtilities
{
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using global::Unsplash.Extensions;
    using global::Unsplash.Requests;
    using Pose;

    internal class ClientTestUtilities
    {
        internal const string RawPhotoList = "[{\"id\": \"1\"," +
                                                  "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                                                  "\"user\": {" +
                                                      "\"id\": \"2\"," +
                                                      "\"links\": {" +
                                                         "\"self\": \"https://a.b.c\"," +
                                                         "\"html\": \"https://a.b.c\"," +
                                                         "\"photos\": \"https://a.b.c\"," +
                                                         "\"likes\": \"https://a.b.c\"," +
                                                         "\"portfolio\": \"https://a.b.c\"," +
                                                         "\"following\": \"https://a.b.c\"," +
                                                         "\"followers\": \"https://a.b.c\"" +
                                                       "}," +
                                                     "\"total_collections\": 1," +
                                                     "\"total_likes\": 2," +
                                                     "\"total_photos\": 3" +
                                                   "}," +
                                                 "\"width\": 200," +
                                                 "\"height\": 100," +
                                                 "\"urls\": {" +
                                                       "\"raw\": \"https://a.b.c\"," +
                                                       "\"full\": \"https://a.b.c\"," +
                                                       "\"regular\": \"https://a.b.c\"," +
                                                       "\"small\": \"https://a.b.c\"," +
                                                       "\"thumb\": \"https://a.b.c\"" +
                                                   "}," +
                                                 "\"likes\": 2" +
                                               "}]";

        internal const string RawCollectionsList = "[" +
                "{" +
                    "\"id\": 1," +
                    "\"title\": \"A\"," +
                    "\"published_at\": \"2020-03-30T17:00:00-02:00\"," +
                    "\"featured\": false," +
                    "\"total_photos\": 1," +
                    "\"cover_photo\": {" +
                        "\"id\": \"1\"," +
                            "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                            "\"user\": {" +
                                "\"id\": \"2\"," +
                                "\"links\": {" +
                                    "\"self\": \"https://a.b.c\"," +
                                    "\"html\": \"https://a.b.c\"," +
                                    "\"photos\": \"https://a.b.c\"," +
                                    "\"likes\": \"https://a.b.c\"," +
                                    "\"portfolio\": \"https://a.b.c\"," +
                                    "\"following\": \"https://a.b.c\"," +
                                    "\"followers\": \"https://a.b.c\"" +
                                "}," +
                                "\"total_collections\": 1," +
                                "\"total_likes\": 2," +
                                "\"total_photos\": 3" +
                            "}," +
                            "\"width\": 200," +
                            "\"height\": 100," +
                            "\"urls\": {" +
                                "\"raw\": \"https://a.b.c\"," +
                                "\"full\": \"https://a.b.c\"," +
                                "\"regular\": \"https://a.b.c\"," +
                                "\"small\": \"https://a.b.c\"," +
                                "\"thumb\": \"https://a.b.c\"" +
                            "}," +
                            "\"likes\": 2" +
                    "}," +
                    "\"user\": {" +
                        "\"id\": \"2\"," +
                        "\"links\": {" +
                            "\"self\": \"https://a.b.c\"," +
                            "\"html\": \"https://a.b.c\"," +
                            "\"photos\": \"https://a.b.c\"," +
                            "\"likes\": \"https://a.b.c\"," +
                            "\"portfolio\": \"https://a.b.c\"," +
                            "\"following\": \"https://a.b.c\"," +
                            "\"followers\": \"https://a.b.c\"" +
                        "}," +
                        "\"total_collections\": 1," +
                        "\"total_likes\": 2," +
                        "\"total_photos\": 3" +
                    "}," +
                    "\"links\": {" +
                        "\"self\": \"http://a.b.c\"," +
                        "\"html\": \"http://a.b.c\"," +
                        "\"photos\": \"http://a.b.c\"," +
                        "\"related\": \"http://a.b.c\"" +
                    "}" +
                "}" +
            "]";

        internal const string RawPhotoSearchResults = "{\"results\": [" +
                                                "{\"id\": \"1\"," +
                                                "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                                                "\"user\": {" +
                                                    "\"id\": \"2\"," +
                                                    "\"links\": {" +
                                                        "\"self\": \"https://a.b.c\"," +
                                                        "\"html\": \"https://a.b.c\"," +
                                                        "\"photos\": \"https://a.b.c\"," +
                                                        "\"likes\": \"https://a.b.c\"," +
                                                        "\"portfolio\": \"https://a.b.c\"," +
                                                        "\"following\": \"https://a.b.c\"," +
                                                        "\"followers\": \"https://a.b.c\"" +
                                                    "}," +
                                                    "\"total_collections\": 1," +
                                                    "\"total_likes\": 2," +
                                                    "\"total_photos\": 3" +
                                                "}," +
                                                "\"width\": 200," +
                                                "\"height\": 100," +
                                                "\"urls\": {" +
                                                    "\"raw\": \"https://a.b.c\"," +
                                                    "\"full\": \"https://a.b.c\"," +
                                                    "\"regular\": \"https://a.b.c\"," +
                                                    "\"small\": \"https://a.b.c\"," +
                                                    "\"thumb\": \"https://a.b.c\"" +
                                                "}," +
                                                "\"likes\": 2" +
                                                "}" +
                                                        "], " +
                                                        "\"total\": 1, " +
                                                        "\"total_pages\": 1}";

        internal const string RawPhoto = "{\"id\": \"1\"," +
                                                "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                                                "\"user\": {" +
                                                    "\"id\": \"2\"," +
                                                    "\"links\": {" +
                                                        "\"self\": \"https://a.b.c\"," +
                                                        "\"html\": \"https://a.b.c\"," +
                                                        "\"photos\": \"https://a.b.c\"," +
                                                        "\"likes\": \"https://a.b.c\"," +
                                                        "\"portfolio\": \"https://a.b.c\"," +
                                                        "\"following\": \"https://a.b.c\"," +
                                                        "\"followers\": \"https://a.b.c\"" +
                                                    "}," +
                                                    "\"total_collections\": 1," +
                                                    "\"total_likes\": 2," +
                                                    "\"total_photos\": 3" +
                                                "}," +
                                                "\"width\": 200," +
                                                "\"height\": 100," +
                                                "\"urls\": {" +
                                                    "\"raw\": \"https://a.b.c\"," +
                                                    "\"full\": \"https://a.b.c\"," +
                                                    "\"regular\": \"https://a.b.c\"," +
                                                    "\"small\": \"https://a.b.c\"," +
                                                    "\"thumb\": \"https://a.b.c\"" +
                                                "}," +
                                                "\"likes\": 2" +
                                            "}";

        internal const string RawCollection = "{" +
                    "\"id\": 1," +
                    "\"title\": \"A\"," +
                    "\"published_at\": \"2020-03-30T17:00:00-02:00\"," +
                    "\"featured\": false," +
                    "\"total_photos\": 1," +
                    "\"cover_photo\": {" +
                        "\"id\": \"1\"," +
                            "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                            "\"user\": {" +
                                "\"id\": \"2\"," +
                                "\"links\": {" +
                                    "\"self\": \"https://a.b.c\"," +
                                    "\"html\": \"https://a.b.c\"," +
                                    "\"photos\": \"https://a.b.c\"," +
                                    "\"likes\": \"https://a.b.c\"," +
                                    "\"portfolio\": \"https://a.b.c\"," +
                                    "\"following\": \"https://a.b.c\"," +
                                    "\"followers\": \"https://a.b.c\"" +
                                "}," +
                                "\"total_collections\": 1," +
                                "\"total_likes\": 2," +
                                "\"total_photos\": 3" +
                            "}," +
                            "\"width\": 200," +
                            "\"height\": 100," +
                            "\"urls\": {" +
                                "\"raw\": \"https://a.b.c\"," +
                                "\"full\": \"https://a.b.c\"," +
                                "\"regular\": \"https://a.b.c\"," +
                                "\"small\": \"https://a.b.c\"," +
                                "\"thumb\": \"https://a.b.c\"" +
                            "}," +
                            "\"likes\": 2" +
                    "}," +
                    "\"user\": {" +
                        "\"id\": \"2\"," +
                        "\"links\": {" +
                            "\"self\": \"https://a.b.c\"," +
                            "\"html\": \"https://a.b.c\"," +
                            "\"photos\": \"https://a.b.c\"," +
                            "\"likes\": \"https://a.b.c\"," +
                            "\"portfolio\": \"https://a.b.c\"," +
                            "\"following\": \"https://a.b.c\"," +
                            "\"followers\": \"https://a.b.c\"" +
                        "}," +
                        "\"total_collections\": 1," +
                        "\"total_likes\": 2," +
                        "\"total_photos\": 3" +
                    "}," +
                    "\"links\": {" +
                        "\"self\": \"http://a.b.c\"," +
                        "\"html\": \"http://a.b.c\"," +
                        "\"photos\": \"http://a.b.c\"," +
                        "\"related\": \"http://a.b.c\"" +
                    "}" +
                "}";

        internal const string RawCollectionSearchResults = "{\"results\": [" +
                "{" +
                    "\"id\": 1," +
                    "\"title\": \"A\"," +
                    "\"published_at\": \"2020-03-30T17:00:00-02:00\"," +
                    "\"featured\": false," +
                    "\"total_photos\": 1," +
                    "\"cover_photo\": {" +
                        "\"id\": \"1\"," +
                            "\"created_at\": \"2020-03-29T11:00:00-02:00\"," +
                            "\"user\": {" +
                                "\"id\": \"2\"," +
                                "\"links\": {" +
                                    "\"self\": \"https://a.b.c\"," +
                                    "\"html\": \"https://a.b.c\"," +
                                    "\"photos\": \"https://a.b.c\"," +
                                    "\"likes\": \"https://a.b.c\"," +
                                    "\"portfolio\": \"https://a.b.c\"," +
                                    "\"following\": \"https://a.b.c\"," +
                                    "\"followers\": \"https://a.b.c\"" +
                                "}," +
                                "\"total_collections\": 1," +
                                "\"total_likes\": 2," +
                                "\"total_photos\": 3" +
                            "}," +
                            "\"width\": 200," +
                            "\"height\": 100," +
                            "\"urls\": {" +
                                "\"raw\": \"https://a.b.c\"," +
                                "\"full\": \"https://a.b.c\"," +
                                "\"regular\": \"https://a.b.c\"," +
                                "\"small\": \"https://a.b.c\"," +
                                "\"thumb\": \"https://a.b.c\"" +
                            "}," +
                            "\"likes\": 2" +
                    "}," +
                    "\"user\": {" +
                        "\"id\": \"2\"," +
                        "\"links\": {" +
                            "\"self\": \"https://a.b.c\"," +
                            "\"html\": \"https://a.b.c\"," +
                            "\"photos\": \"https://a.b.c\"," +
                            "\"likes\": \"https://a.b.c\"," +
                            "\"portfolio\": \"https://a.b.c\"," +
                            "\"following\": \"https://a.b.c\"," +
                            "\"followers\": \"https://a.b.c\"" +
                        "}," +
                        "\"total_collections\": 1," +
                        "\"total_likes\": 2," +
                        "\"total_photos\": 3" +
                    "}," +
                    "\"links\": {" +
                        "\"self\": \"http://a.b.c\"," +
                        "\"html\": \"http://a.b.c\"," +
                        "\"photos\": \"http://a.b.c\"," +
                        "\"related\": \"http://a.b.c\"" +
                    "}" +
                "}" +
            "]," +
            "\"total\": 2," +
            "\"total_pages\": 1}";

        internal const string RawPhotoDownloadMarked = "{\"url\": \"https://a.b.c\"}";

        internal const string RawStats = "{\"downloads\": {\"total\": 1}}";

        internal static T Deserialize<T>(string s)
        {
            var bytes = s.ToByteArray();
            return (T)JsonSerializer.Deserialize(new ReadOnlySpan<byte>(bytes), typeof(T));
        }

        internal static TResponseReference ShimGetAsync<TRequest, TResponseReference>()
            where TRequest : Request
        {
            (HttpResponseMessage response, TResponseReference expected) =
                MockHttpResponse<TRequest, TResponseReference>();
            Shim.Replace(() => Is.A<HttpClient>().GetAsync(Is.A<Uri>()))
                                 .With((HttpClient @this, Uri uri) =>
                                 {
                                     return new Task<HttpResponseMessage>(() => response);
                                 });
            return expected;
        }

        internal static Shim ShimGetByteArrayAsync(byte[] buffer)
        {
            return Shim.Replace(() => Is.A<HttpClient>().GetByteArrayAsync(Is.A<Uri>()))
                                        .With((HttpClient @this, Uri uri) =>
                                        {
                                            return new Task<byte[]>(() => buffer);
                                        });
        }

        internal static Shim ShimFileCreate()
        {
            return Shim.Replace(() => File.Create(Is.A<string>()))
                                          .With((string s) =>
                                          {
                                              return new FileStream(@"C:\Users\Iliyan\Desktop\temp",
                                                                    FileMode.Create,
                                                                    FileAccess.Write);
                                          });
        }

        internal static (HttpResponseMessage Response, TResponseReference Reference) MockHttpResponse<TRequest, TResponseReference>()
            where TRequest : Request
        {
            (StringContent content, TResponseReference expected) = typeof(TRequest).ToString() switch
            {
                "Unsplash.Requests.ListPhotosRequest" =>
                    (Content: new StringContent(RawPhotoList),
                     Expected: Deserialize<TResponseReference>(RawPhotoList)),
                "Unsplash.Requests.GetPhotoRequest" =>
                    (Content: new StringContent(RawPhoto),
                     Expected: Deserialize<TResponseReference>(RawPhoto)),
                "Unsplash.Requests.GetRandomPhotoRequest" =>
                    (Content: new StringContent(RawPhoto),
                     Expected: Deserialize<TResponseReference>(RawPhoto)),
                "Unsplash.Requests.GetRandomPhotosRequest" =>
                    (Content: new StringContent(RawPhotoList),
                     Expected: Deserialize<TResponseReference>(RawPhotoList)),
                "Unsplash.Requests.GetPhotoStatsRequest" =>
                    (Content: new StringContent(RawStats),
                     Expected: Deserialize<TResponseReference>(RawStats)),
                "Unsplash.Requests.SearchPhotosRequest" =>
                    (Content: new StringContent(RawPhotoSearchResults),
                     Expected: Deserialize<TResponseReference>(RawPhotoSearchResults)),
                "Unsplash.Requests.DownloadPhotoRequest" =>
                    (Content: new StringContent(RawPhotoDownloadMarked),
                     Expected: Deserialize<TResponseReference>(RawPhotoDownloadMarked)),
                "Unsplash.Requests.SearchCollectionsRequest" =>
                    (Content: new StringContent(RawCollectionSearchResults),
                     Expected: Deserialize<TResponseReference>(RawCollectionSearchResults)),
                "Unsplash.Requests.ListFeaturedCollectionsRequest" =>
                    (Content: new StringContent(RawCollectionsList),
                     Expected: Deserialize<TResponseReference>(RawCollectionsList)),
                "Unsplash.Requests.GetCollectionRequest" =>
                    (Content: new StringContent(RawCollection),
                     Expected: Deserialize<TResponseReference>(RawCollection)),
                "Unsplash.Requests.GetCollectionPhotosRequest" =>
                    (Content: new StringContent(RawPhotoList),
                     Expected: Deserialize<TResponseReference>(RawPhotoList)),
                "Unsplash.Requests.ListRelatedCollectionsRequest" =>
                    (Content: new StringContent(RawCollectionsList),
                     Expected: Deserialize<TResponseReference>(RawCollectionsList)),
                _ => throw new Exception()
            };
            return (Response: new HttpResponseMessage() { Content = content }, expected);
        }
    }
}
