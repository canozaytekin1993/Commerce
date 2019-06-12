using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Domain.Entities.Media;

namespace Commerce.Contracts.Factories
{
    public interface IImageFactory
    {
        Task<Image> GetImageAsync(int imageid);
        Task<bool> AddImageAsync(Image image);
        Task<bool> AddImageAsync(List<Image> images);
        Task<bool> RemoveImageAsync(int imageId);
        Task<bool> RemoveImageAsync(List<int> imageIds);
        Task<ICollection<Image>> GetImageAsync();
    }
}