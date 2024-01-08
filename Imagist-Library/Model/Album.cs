using System.ComponentModel.DataAnnotations.Schema;

namespace Imagist_Library.Model;

public class Album
{
    public long AlbumId { get; set; }
    public string AlbumName { get; set; }
    public string AlbumDescription { get; set; }
    
    public long OwingUserId { get; set; }
    [ForeignKey(nameof(OwingUserId))]
    public User OwingUser { get; set; }
    public List<Photo> Photos { get; set; }

}