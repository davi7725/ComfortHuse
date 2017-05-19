using System.Drawing;

namespace Comforthuse.Models
{
    public class Image : IImage
    {
        public string Title { get; set; }
        public Bitmap SrcImage { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }

    public interface IImage

    {
        string Title { get; }
        Bitmap SrcImage { get; }
        string Path { get; set; }
        string Description { get; set; }
    }
}
