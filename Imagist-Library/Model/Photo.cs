using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Imagist_Library.Photo;

namespace Imagist_Library.Model;

public class Photo
{
    //self attribute
    [Key]
    public long PhotoId { get; set; }
    public string ObjectId { get; set; }
    //缩略图
    public string ThumbnailObjectId { get; set; }
    public bool Delete { get; set; }

    public PhotoMetaData MetaData { get; set; }
    //relation
    public long OwingUserId { get; set; }
    [ForeignKey(nameof(OwingUserId))]
    public User OwingUser { get; set; }
    public long AlbumId { get; set; }
    [ForeignKey(nameof(AlbumId))]
    public Album Album { get; set; }
}