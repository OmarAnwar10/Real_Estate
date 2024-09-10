using API_Project.DataAccessContracts;
using application.DataAccess.Models;

namespace Application.DataAccessContracts
{
    public interface IUnitOfWork
    {
        IPropertyRepository Property { get; }
        IUserRepository User { get; }
        IInquiryRepository Inquiry { get; }
        IFavoriteRepository Favorite { get; }
        void Save();
    }
}
