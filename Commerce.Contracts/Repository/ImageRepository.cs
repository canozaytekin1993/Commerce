using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Domain.Entities.Media;

namespace Commerce.Contracts.Repository
{
    public interface ImageRepository
    {
        Task<Image> GetImageAsync(int imageId);
        Task<bool> AddImageAsync(Image image);
        Task<bool> RemoveImageAsync(int imageId);
        Task<bool> UpdateImageAsync(Image image);

        // Bulk action
        Task<bool> AddImageAsync(List<Image> images);
        Task<bool> RemoveImageAsync(List<int> imageIds);
        Task<bool> UpdateImageAsync(List<Image> images);
    }
}