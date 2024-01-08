using System.Globalization;
using System.Text.RegularExpressions;
using ImageMagick;
using MetadataExtractor;
using Microsoft.AspNetCore.Http;

namespace Imagist_Library.Photo;

public class PhotoExtractor
{
    public static PhotoMetaData ExtractPhotoMetaData(IFormFile file)
    {
        var metadata = ImageMetadataReader.ReadMetadata(file.OpenReadStream());
        var image = new MagickImage(file.OpenReadStream());
        
        CultureInfo provider = CultureInfo.InvariantCulture;
        //EXIF信息中 Exif IFD0 子目录
        var exifIfd0 =
            metadata.FirstOrDefault(d => d.Name.Equals("Exif IFD0"))?.Tags.ToDictionary(tag => tag.Name,tag => tag.Description)??new Dictionary<string, string>();
        //EXIF信息中 Exif SubIFD 子目录
        var exifSubIfd  = 
            metadata.FirstOrDefault(d => d.Name.Equals("Exif SubIFD"))?.Tags.ToDictionary(tag => tag.Name,tag => tag.Description)?? new Dictionary<string, string>();
        //EXIF信息中 File Type 子目录
        var fileType  = 
            metadata.FirstOrDefault(d => d.Name.Equals("File Type"))?.Tags.ToDictionary(tag => tag.Name,tag => tag.Description)??new Dictionary<string, string>();
        var metaData = new PhotoMetaData()
        {
            ImageHeight = image.Height,
            ImageWidth = image.Width,
            Make = exifIfd0.ContainsKey("Make")?exifIfd0["Make"]:null,
            Model = exifIfd0.ContainsKey("Model")?exifIfd0["Model"]:null, 
            OriginalTime = exifIfd0.ContainsKey("Date/Time Original") ? DateTime.ParseExact(exifSubIfd?["Date/Time Original"]!,"yyyy:MM:dd HH:mm:ss",provider) : DateTime.Now,
            Lens = exifSubIfd.ContainsKey("Lens Model") ?exifSubIfd?["Lens Model"] : null,
            Aperture = exifSubIfd.ContainsKey("F-Number") ?exifSubIfd?["F-Number"] : null,
            ShutterSpeed = exifSubIfd.ContainsKey("Shutter Speed Value")?exifSubIfd["Shutter Speed Value"] : null,
            ISO = exifSubIfd.ContainsKey("ISO Speed Ratings")?exifSubIfd["ISO Speed Ratings"]: null,
            FocalLength35 =exifSubIfd.ContainsKey("ISO Speed Ratings")? exifSubIfd?["ISO Speed Ratings"] : null,
            FileType = fileType.ContainsKey("Detected File Type Name")?fileType?["Detected File Type Name"]: null,
            FileExtensionName = fileType.ContainsKey("Expected File Name Extension") ? fileType["Expected File Name Extension"]:null,
            MIMEType = fileType.ContainsKey("Detected MIME Type") ? fileType?["Detected MIME Type"] : null
         };
        return metaData;
    }
}