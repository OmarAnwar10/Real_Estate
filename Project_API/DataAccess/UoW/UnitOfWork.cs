using API_Project.DataAccessContracts;
using application.DataAccess;
using Application.DataAccessContracts;



namespace API_Project.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IInquiryRepository _inquiryRepository;
        private readonly IFavoriteRepository _favoriteRepository;

        public UnitOfWork(AppDbContext context,
                          IPropertyRepository propertyRepository,
                          IUserRepository userRepository,
                          IInquiryRepository inquiryRepository,
                          IFavoriteRepository favoriteRepository)
        {
            _context = context;
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
            _inquiryRepository = inquiryRepository;
            _favoriteRepository = favoriteRepository;
        }

        public IPropertyRepository Property => _propertyRepository;
        public IUserRepository User => _userRepository;
        public IInquiryRepository Inquiry => _inquiryRepository;
        public IFavoriteRepository Favorite => _favoriteRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
