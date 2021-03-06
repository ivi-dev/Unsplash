# What is it?
Unsplash is a .NET Core 3.1 library for getting freely usable photos from the [Unsplash web service](https://unsplash.com). 

The library gives you free access to a vast array of freely distributable photos and photo collections. 
It lets you list, search through and download via an easy to use, clean [API](#public-api).

The UnsplashLibrary is distributed as a NuGet package for easy integration into .NET projects of various kinds.

# How do I use it?
First you have to install it into your project by one of the following ways (make sure to substitude `<desired-version-here>` with the version number you want):

- **Package Manager Console**: `Install-Package UnsplashClient -Version <desired-version-here>`
- **.NET CLI**: `dotnet add package UnsplashClient --version <desired-version-here>`
- **PackageReference** in your project config: `<PackageReference Include="UnsplashClient" Version="<desired-version-here>" />`.

Then, make a new instance of the [Unsplash.Client](#Client) class and call any of its public methods 
to get data.

Here's a list of the client's public API:

<span id="public-api"></span>
## Working with photos:
- ListPhotosAsync([ListPhotosRequest](#ListPhotosRequest)? request = null)
  - Get a list of [Photo](#Photo) objects asynchronously.
  - **Arguments:** A [ListPhotosRequest](#ListPhotosRequest) object with 
    parameters for the request (optional). 
    If left at `null`, [default parameters](#default-parameters) are used.
  - **Returns:** A `List<Photo>` object.
  
- GetPhotoAsync(string id)
  - Get data for a single photo asynchronously.
  - **Arguments:** The `id` of the photo you want to get data for. 
    Typically you get photo ids from method that return [Photo](#Photo) or `List<Photo>`.
  - **Returns:** A [Photo](#Photo) object.
  
- GetRandomPhotoAsync([GetRandomPhotoRequest](#GetRandomPhotoRequest)? request = null)
  - Get a random photo asynchronously.
  - **Arguments:** A [GetRandomPhotoRequest](#GetRandomPhotoRequest) object with 
    parameters for the request (optional).
    If left at `null`, [default parameters](#default-parameters) are used.
  - **Returns:** A [Photo](#Photo) object.
  
- GetRandomPhotosAsync(uint count)
  - Get a list of random photos asynchronously.
  - **Arguments:** A `count` that signifies the number of photos to get.
  - **Returns:** A `List<Photo>` object.
  
- GetRandomPhotosAsync([GetRandomPhotosRequest](#GetRandomPhotosRequest)? request = null)
  - Get a list of random photos asynchronously.
  - **Arguments:** A [GetRandomPhotosRequest](#GetRandomPhotosRequest) object with 
    parameters for the request (optional).
    If left at `null`, [default parameters](#default-parameters) are used.
  - **Returns:** A `List<Photo>` object.
  
- GetPhotoStatsAsync(string id)
  - Get photo [Stats](#Stats) asynchronously.
  - **Arguments:** The `id` of the photo you want to get stats for. 
    Typically you get photo ids from method that return [Photo](#Photo) or `List<Photo>`.
  - **Returns:** A [Stats](#Stats) object.
  
- GetPhotoStatsAsync(GetPhotoStatsRequest request)
  - Get photo [Stats](#Stats) asynchronously.
  - **Arguments:** A [GetPhotoStatsRequest](#GetPhotoStatsRequest) object with 
    parameters for the request.
  - **Returns:** A [Stats](#Stats) object.
  
- SearchPhotosAsync(string query)
  - Search for photos asynchronously.
  - **Arguments:** A search term to find photos by.
  - **Returns:** A [Photos.SearchResults](#Photos-SearchResults) object.
  
- SearchPhotosAsync([SearchPhotosRequest](#SearchPhotosRequest) request)
  - Search for photos asynchronously.
  - **Arguments:** A [SearchPhotosRequest](#SearchPhotosRequest) object with 
    parameters for the request.
  - **Returns:** A [Photos.SearchResults](#Photos-SearchResults) object.
  - **Throws:** An `ArgumentNullException` if `request` is null.
  
- DownloadPhotoAsync(Uri url, string id, string destination)
  - Download a photo asynchronously.
  - **Arguments:** A `url` of the photo, its `id` used to mark the photo as downloaded 
    (Unsplash policy) and the file system `destination` of the downloaded file. 
  - **Returns:** The length in bytes of the downloaded file.
  
- DownloadPhotoAsync([DownloadPhotoRequest](#DownloadPhotoRequest) request, string id, 
  string destination)
  - Download a photo asynchronously.
  - **Arguments:** A [DownloadPhotoRequest](#DownloadPhotoRequest) object with 
    parameters for the request, the photo's `id` used to mark the photo as downloaded 
    (Unsplash policy) and the file system `destination` of the downloaded file. 
  - **Returns:** The length in bytes of the downloaded file.
  - **Throws:** An `ArgumentNullException` if `request` is null.
  
 
  <span id="Photo"></span>
### Unspslash.Photos.Photo
A class that describes a photo. It has these public properties:
- string **id** - the photo's id
- DateTime **created_at** - creation date
- [User](#User) **user** - the author of the photo
- uint **width** - photo's width in pixels
- uint **height** - photo's height in pixels
- [DownloadURLs](#DownloadURLs) **urls** - a set of URLs that you can use to download 
  the photo from
- uint **likes** - number of likes the photo has
- string **color** - the average color of the photo
- string **description** - the photo's description
- string **alt_description** - the photo's alternate description

<span id="DownloadURLs"></span>
### Unspslash.Photos.DownloadURLs
A class that contains URLs to an image. The URLs can be used for photo download.
The class has these public properties:
- Uri **raw** - a path to the raw photo.
- Uri **full** - a path to the photo in full resolution.
- Uri **regular** - a path to the photo in regular resolution.
- Uri **small** - a path to the photo in small resolution.
- Uri **thumb** - a path to the photo in thumbnail resolution.
  
<span id="Stats"></span>
### Unspslash.Photos.Stats
A class that contains stats of a photo. It has these public properties:

- [Downloads](#Downloads) **downloads** - the download stats of a photo

<span id="Downloads"></span>
### Unspslash.Photos.Downloads
A class that contains download stats of a photo. It has these public properties:

- uint **total** - the total number of downloads of a photo

<span id="Photos-SearchResults"></span>
### Unspslash.Photos.SearchResults
A class that contains the results of a photo search. It has these public properties:

- List<Photo> **results** - a `List<Photo>` of search matches
- uint **total** - a number of total matches matches
- uint **total_pages** - a number of results pages
  
<span id="Sort"></span>
### Unsplash.Photos.Sort
An enumeration of photo sorting options. Aailable options:
`RELEVANAT`, `LATEST`.

<span id="Crop"></span>
### Unsplash.Photos.Crop
An enumeration of photo cropping options. Aailable options:
`TOP`, `BOTTOM`, `LEFT`, `RIGHT`, `FACES`, `FOCAL_POINT`, `EDGES`, `ENTROPY`.

<span id="Format"></span>
### Unsplash.Photos.Format
An enumeration of photo formatting options. Aailable options:
`GIF`, `JP2`, `JPG`, `JSON`, `JXR`, `PJPG`, `MP4`, `PNG`, `PNG8`, `PNG32`, 
`WEBM`, `WEBP`.

<span id="Fit"></span>
### Unsplash.Photos.Fit
An enumeration of photo fitting options. Aailable options:
`CLAMP`,
`CLIP`,
`CROP`,
`FACEAREA`,
`FILL`,
`FILLMAX`,
`MAX`,
`MIN`,
`SCALE`.

<span id="ColorFilter"></span>
### Unsplash.Photos.ColorFilter
An enumeration of photo color filters. Aailable options:
`BLACK_AND_WHITE`, `BLACK`, `WHITE`, `YELLOW`, `ORANGE`, `RED`, `PURPLE`, 
`MAGENTA`, `GREEN`, `TEAL`, `BLUE`.

<span id="Orientation"></span>
### Unsplash.Photos.Orientation
An enumeration of photo orientations. Aailable options:
`LANDSCAPE`, `PORTRAIT`, `SQUARISH`.

  
  
  
  
  
  
## Working with photo collections
- SearchCollectionsAsync(string query)
  - Search for collections asynchronously.
  - **Arguments:** A search term to find collections by.
  - **Returns:** A [Collections.SearchResults](#Collections-SearchResults) object.
  
- SearchCollectionsAsync([SearchCollectionsRequest](#SearchCollectionsRequest) request)
  - Search for collections asynchronously.
  - **Arguments:** A [SearchCollectionsRequest](#SearchCollectionsRequest) object with 
    parameters for the request
  - **Returns:** A [Collections.SearchResults](#Collections-SearchResults) object.
  - **Throws:** An `ArgumentNullException` if `request` is null.
  
- ListFeaturedCollectionsAsync([ListFeaturedCollectionsRequest](#ListFeaturedCollectionsRequest) request)
  - List featured collections asynchronously.
  - **Arguments:** A [ListFeaturedCollectionsRequest](#ListFeaturedCollectionsRequest) object with 
    parameters for the request (optional).
  - **Returns:** A `List<Collection>` object.
  
- GetCollectionAsync(string id)
  - Get data for a single [Collection](#Collection) asynchronously.
  - **Arguments:** The `id` of the collection to get data for.
  - **Returns:** A [Collection](#Collection) object.
  
- GetCollectionPhotosAsync(string id)
  - Get a list of [Photo](#Photo)s in a [Collection](#Collection) asynchronously.
  - **Arguments:** The `id` of the collection to get the photos of.
  - **Returns:** A `List<Photo>` object.
  
- ListRelatedCollectionsAsync(string id)
  - Get a list of collections related to a [Collection](#Collection), asynchronously.
  - **Arguments:** The `id` of the collection to get related collections of.
  - **Returns:** A `List<Collection>` object.


<span id="Collection"></span>
### Unspslash.Photos.Collection
A class that describes a Collection. It has these public properties:
- string **id** - the collection's id.
- string **title** - the collection's title.
- string **description** - the collection's description.
- DateTime **published_at** - the collection's date of publishing.
- bool **featured** - weather the collection is featured or not.
- uint **total_photos** - total number of photos in the collection.
- [Photo](#Photo) **cover_photo** - the collection's cover photo.
- [User](#User) **user** - the collection's author.
- [Links](#Links) **links** - links to the collection on the web.

There's also a `ToString()` method that returns a summary of the collection's attributes.

<span id="Collections-SearchResults"></span>
### Unspslash.Collections.SearchResults
A class that contains the results of a collection search. It has these public properties:

- **results** - a `List<Collection>` with search matches
- **total** - a number of total matches matches
- **total_pages** - a number of results pages






## Users
<span id="User"></span>
## Unspslash.Users.User
A class that describes a user. It has these public properties:
- string **id** - the user's id.
- [Links](#Links) **links** - links to user's resources.
- uint **total_collections** - total number of collections the user has.
- uint **total_likes** - total number of likes the user has accumulated.
- uint **total_photos** - total number of photos the user has.
- string **first_name** - the user's first name.
- string **last_name** - the user's last name.
- Uri **portfolio_url** - a link to the user's portfolio.
- string **bio** - the user's bio.
- string **location** - the user's location.
- [ProfileImage](#ProfileImage) **id** - the user's profile image.


<span id="Links"></span>
## Unspslash.Users.Links
A class that contains links to a user's web resources. It has these public properties:
- Uri **self** - a link to the user's profile page.
- Uri **html** - a link to the user's web page.
- Uri **photos** - a link to the user's photos.
- Uri **likes** - a link to the user's likes page.
- Uri **portfolio** - a link to the user's portfolio.
- Uri **following** - a link to the user's 'following' page.
- Uri **followers** - a link to the user's 'followers' page.

<span id="ProfileImage"></span>
## Unspslash.Users.ProfileImage
A class that describes a user's profile image. It has these public properties:
- Uri **small** - a link to the user's small sized profile image.
- Uri **medium** - a link to the user's medium sized profile page.
- Uri **large** - a link to the user's large sized profile page.
  
  
  
  
  

<span id="request-types"></span>
## Requests
<span id="ListPhotosRequest"></span>
### Unsplash.Requests.ListPhotosRequest
Construct it to set parameters for a request to list photos.
The class accepts these optional arguments in its constructor. 
If any of them is not provided an Unsplash web service [default value](#default-parameters) is used:
- [Order](#Order)? **order** - the ordering to apply to photos.
- uint? **page** - the page to show.
- uint? **perPage** - the number of photos to show per page.

<span id="GetRandomPhotoRequest"></span>
### Unsplash.Requests.GetRandomPhotoRequest
Construct it to set parameters for a request for a random photo.
The class accepts these arguments in its constructor:
- [Orientation](#Orientation)? **orientation** - the orientation of the photo.
- string[]? **collections** - tells the service to get random photos from these collections only.
- bool? **featured** - weather to get only featured photos or not.
- string? **username** - get photos only by that user.
- string? **query** - get photos that match that query only.

<span id="SearchPhotosRequest"></span>
### Unsplash.Requests.SearchPhotosRequest
Construct it to set parameters for a photo search request.
The class accepts these arguments in its constructor:
- string? **query** - a search term.
- uint? **page** - the result page to show.
- uint? **perPage** - number of matches to show per page.
- [Sort](#Sort)? **sort** - the sorting to apply to the result.
- string[]? **collections** - search only these collections.
- [ColorFilter](#ColorFilter)? **color** - search only for photos with this color filter. 
- [Orientation[(#Orientation)? **orientation** - search only for photos with this orientation.

<span id="SearchCollectionsRequest"></span>
### Unsplash.Requests.SearchCollectionsRequest
Construct it to set parameters for a photo search request.
The class accepts these arguments in its constructor:
- string? **query** - a search term.
- uint? **page** - the result page to show.
- uint? **perPage** - number of matches to show per page.

<span id="ListFeaturedCollectionsRequest"></span>
### Unsplash.Requests.ListFeaturedCollectionsRequest
Construct it to set parameters for a request to list featured collections.
The class accepts these arguments in its constructor:
- uint? **page** - the result page to show.
- uint? **perPage** - number of matches to show per page.


<span id="DownloadPhotoRequest"></span>
### Unsplash.Requests.DownloadPhotoRequest
Construct it to set parameters for a photo download request.
The class accepts these arguments in its constructor:
- Uri? **baseUrl** - a photo's ownload location.
- uint? **width** - the photos desired width in pixels.
- uint? **height** - the photos desired height in pixels.
- [Crop](#Crop)? **crop** - a cropping mode.
- [Format](#Format)? **format** - a photo format.
- uint? **quality** - sets the quality of the photo to be downloaded, us a number from 0 to 100.
- [Fit](#Fit)? **fit** - a fit mode.
- uint? **dpi** - sets the dpi of the photo to be downloaded.

<span id="GetRandomPhotosRequest"></span>
### Unsplash.Requests.GetRandomPhotosRequest
Construct it to set parameters for a request for a random photo.
The class accepts the same arguments in its constructor as 
[Unsplash.Requests.GetRandomPhotoRequest](#GetRandomPhotoRequest) plus this one:
- uint **count** - the number of photos to get.

<span id="GetPhotoStatsRequest"></span>
### Unsplash.Requests.GetPhotoStatsRequest
Construct it to set parameters for a request for photo stats.
The class accepts these arguments in its constructor:
- string **id** - the id of the photo.
- [StatsResolution](#StatsResolution)? **resolution** - the resolution of the stats report (currently only `StatsResolution.DAYS` is supported).
- uint? **quantity** - the number of resolution units to get. For example a value of '1' here and 
`StatsResolution.DAYS` for the 'resolution' will get photo stats for one day.

## The Unsplash.Client class
<span id="Client"></span>
The **Unsplash.Client** class is the main gateway into the system. In order to use its [APIs](#public-api) 
you instantiate it with an Unsplash API access key which you can obtain from 
[Unsplash Developer](https://unsplash.com/oauth/applications).

## Default parameter values
<span id="default-parameters"></span>
The Unsplash web service has some default parameter values it uses when processing requests to it, in case those parameters had not been specified explicitly. Remember, you can set request parameters through an instance of a class from the [Unsplash.Requests](#request-types) namespace, whenever it is required as an argument in any of the [public APIs](#public-api).

Here are some of the default values. The left column lists parameter names as you would see them in [Request classes] (#request-types) constructors and the right one lists Unsplash services default values. For example, if you do not specify a value for a `page` parameter in a class's constructor, '1' is going to be recieved by the Unsplash serice. 

| Parameter Name | Default Value                
|----------------|------------------------------
| page           | 1                            
| perPage        | 10                           
| order          | Unsplash.Photos.Order.LATEST 
| resolution     | Unsplash.Photos.StatsResolution.DAYS
| quantity       | 30
