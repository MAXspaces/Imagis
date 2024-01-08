using System.Text.Json.Serialization;
using Imagist_Library.Serialization;

namespace Imagist_Library.Apis.AlbumApi;

public class AlbumDto
{
    [JsonConverter(typeof(IdToStringConverter))]
    public long AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string AlbumDescription { get; set; }
}