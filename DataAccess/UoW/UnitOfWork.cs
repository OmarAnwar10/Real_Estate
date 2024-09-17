using _DataAccess.Contracts;
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
        private readonly IPropertyImageRepository _propertyImageRepository;
        private readonly IAmenitiesRepository _amenitiesRepository;

        public UnitOfWork(AppDbContext context,
                          IPropertyRepository propertyRepository,
                          IUserRepository userRepository,
                          IInquiryRepository inquiryRepository,
                          IFavoriteRepository favoriteRepository,
                          IPropertyImageRepository propertyImageRepository,
                          IAmenitiesRepository AmenitiesRepository)
        {
            _context = context;
            _propertyRepository = propertyRepository;
            _userRepository = userRepository;
            _inquiryRepository = inquiryRepository;
            _favoriteRepository = favoriteRepository;
            _propertyImageRepository = propertyImageRepository;
            _amenitiesRepository = AmenitiesRepository;
        }

        public IPropertyRepository Property => _propertyRepository;
        public IUserRepository User => _userRepository;
        public IInquiryRepository Inquiry => _inquiryRepository;
        public IFavoriteRepository Favorite => _favoriteRepository;
        public IPropertyImageRepository PropertyImage => _propertyImageRepository;
        public IAmenitiesRepository Amenities => _amenitiesRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
