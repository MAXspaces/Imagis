using Microsoft.EntityFrameworkCore;

namespace Imagist_Library.Photo;
[Owned]
public class PhotoMetaData
{
    //文件类型名
    public string? FileType { get; set; }
    //文件扩展名
    public string? FileExtensionName { get; set; }
    //文件类型
    public string? MIMEType { get; set; }

    //照片高度（像素）
    public int ImageHeight { get; set; }
    //照片宽度（像素）
    public int ImageWidth { get; set; }
    //制造厂商
    public string? Make { get; set; }
    //设备
    public string?  Model { get; set; }
    //拍摄日期
    public DateTime? OriginalTime { get; set; }

    //镜头
    public string? Lens { get; set; }
    //光圈
    public string? Aperture { get; set; }
    //快门
    public string? ShutterSpeed { get; set; }
    //ISO
    public string? ISO { get; set; }
    //焦段
    public string? FocalLength35 { get; set; }

}