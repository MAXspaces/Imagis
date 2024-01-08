using System.Text.Json.Serialization;
using Imagist_Library.Photo;
using Imagist_Library.Serialization;

namespace Imagist_Library.Apis.PhotoApi;

public class PhotoDto
{
    [JsonConverter(typeof(IdToStringConverter))]
    public long PhotoId { get; set; }
    [JsonConverter(typeof(IdToStringConverter))]
    public long AlbumId { get; set; }
    public string Url { get; set; }
    //缩略图
    public string ThumbnailObjectUrl { get; set; }
    public PhotoMetaData MetaData { get; set; }

}