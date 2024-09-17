using _DataAccess.Contracts;
using _DataAccess.Models;
using API_Project.DataAccess.Repositories;
using application.DataAccess;

namespace _DataAccess.Repositories
{
    internal class PropertyImageRepository : BaseRepository<PropertyImage>, IPropertyImageRepository
    {
        public PropertyImageRepository(AppDbContext context) : base(context)
        {
        }

        public void UpdateAllPropertyImages(int propertyId, IEnumerable<string> images)
        {
            if (images.Count() == 0)
                return;

            var propertyImages = _dbSet.Where(x => x.PropertyId == propertyId).ToList();

            foreach (var image in propertyImages)
            {
                _dbSet.Remove(image);
            }

            foreach (var image in images)
            {

                _dbSet.Add(new PropertyImage { PropertyId = propertyId, Url = image });
            }
        }

        public void UpdatePropertyImage(int propertyId, int imageId, string image)
        {
            var propertyImage = _dbSet.FirstOrDefault(x => x.PropertyId == propertyId && x.Id == imageId);

            if (propertyImage != null)
            {
                propertyImage.Url = image;
            }
        }
    }
}
