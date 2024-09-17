using API_Project.DataAccess.Models;
using API_Project.DataAccessContracts;
using application.DataAccess;

namespace API_Project.DataAccess.Repositories
{
    internal class InquiryRepository : BaseRepository<Inquiry>, IInquiryRepository
    {
        public InquiryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
