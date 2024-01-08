using Imagist_Library.Model;

namespace Imagist_Library.Apis.AlbumApi;

public class CreateAlbumRequest
{
    public string AlbumName { get; set; }
    public string AlbumDescription { get; set; }
}