using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Contracts.Handlers;
using Commerce.Contracts.Repository;
using Commerce.Contracts.Validators;
using Commerce.Domain.Entities.Media;

namespace Commerce.Logics.Managers
{
    public class ImageManager : IImageRepository
    {
        private readonly IImageFactory _factory;
        private readonly IExceptionHandler _handler;
        private readonly IValidator<Image> _validator;

        public ImageManager(IImageFactory factory, IValidator<Image> validator, IExceptionHandler handler)
        {
            _factory = factory;
            _validator = validator;
            _handler = handler;
        }

        public async Task<Image> GetImageAsync(int imageid)
        {
            if (imageid < 1) return null;
            return await _handler.Run(() => _factory.GetImageAsync(imageid));
        }

        public async Task<bool> AddImageAsync(Image image)
        {
            if (image == null || !_validator.IsValid(image)) return false;
            return await _handler.Run(() => _factory.AddImageAsync(image));
        }

        public async Task<bool> AddImageAsync(List<Image> images)
        {
            if (!images.Any())
                return false;
            return await _handler.Run(() => _factory.AddImageAsync(images));
        }

        public async Task<bool> RemoveImageAsync(int imageId)
        {
            if (imageId < 1) return false;
            return await _handler.Run(() => _factory.RemoveImageAsync(imageId));
        }

        public async Task<bool> RemoveImageAsync(List<int> imageIds)
        {
            if (!imageIds.Any()) return false;
            return await _handler.Run(() => _factory.RemoveImageAsync(imageIds));
        }

        public async Task<ICollection<Image>> GetImageAsync()
        {
            return await _handler.Run(() => _factory.GetImageAsync());
        }
    }
}