using _DataAccess.Contracts;
using API_Project.DataAccessContracts;

namespace Application.DataAccessContracts
{
    public interface IUnitOfWork
    {
        IPropertyRepository Property { get; }
        IUserRepository User { get; }
        IInquiryRepository Inquiry { get; }
        IFavoriteRepository Favorite { get; }
        IPropertyImageRepository PropertyImage { get; }
        IAmenitiesRepository Amenities { get; }

        void Save();
    }
}
