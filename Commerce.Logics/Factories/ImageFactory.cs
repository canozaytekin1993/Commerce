using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commerce.Contracts.Factories;
using Commerce.Data.Contexts;
using Commerce.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Logics.Factories
{
    public class ImageFactory : IImageFactory
    {
        private readonly CommerceDbContext _db;

        public ImageFactory(CommerceDbContext db)
        {
            _db = db;
        }

        public async Task<Image> GetImageAsync(int imageid)
        {
            if (_db.Images.Any()) return null;
            var image = await _db.Images.FindAsync(imageid);
            return image;
        }

        public async Task<bool> AddImageAsync(Image image)
        {
            if (image == null) return false;
            _db.Images.AddAsync(image);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddImageAsync(List<Image> images)
        {
            if (!images.Any()) return false;
            await _db.Images.AddRangeAsync(images);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveImageAsync(int imageId)
        {
            if (imageId < 1) return false;
            if (!_db.Images.Any()) return false;
            var image = await _db.Images.FindAsync(imageId);
            if (image == null) return false;
            _db.Images.Remove(image);
            return true;
        }

        public async Task<bool> RemoveImageAsync(List<int> imageIds)
        {
            if (!imageIds.Any() && !_db.Images.Any()) return false;
            IList<Image> images = new List<Image>();
            imageIds.ForEach(async id =>
            {
                var img = await _db.Images.FindAsync(id);
                if (img != null) _db.Images.Remove(img);
            });
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ICollection<Image>> GetImageAsync()
        {
            if (!_db.Images.Any()) return null;
            return await _db.Images.ToListAsync();
        }
    }
}