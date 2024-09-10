using API_Project.DataAccess.Models;
using API_Project.DataAccessContracts;
using application.DataAccess;
using application.DataAccess.Models;
using Application.DataAccessContracts;

namespace API_Project.DataAccess.Repositories
{
    public class InquiryRepository : BaseRepository<Inquiry>, IInquiryRepository
    {
        public InquiryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
