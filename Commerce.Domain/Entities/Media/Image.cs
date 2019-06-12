using Commerce.Domain.Entities.BaseModels;

namespace Commerce.Domain.Entities.Media
{
    public class Image
    { 
        public string MimeType { get; set; }
        public string ImageName { get; set; }
        public int ImageSize { get; set; }
        public ImageBinary ImageBinary { get; set; }
    }

    public class ImageBinary : BaseEntity
    {
        public byte[] ImageBytes { get; set; }
        public Image Image { get; set; }
    }
}