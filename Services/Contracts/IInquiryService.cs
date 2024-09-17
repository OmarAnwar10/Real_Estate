using _Services.Models.Inquiry;

namespace _Services.Contracts
{
    public interface IInquiryService
    {
        void CreateInquiry(Inquiry_Create _inquiry);
        void UpdateInquiry(int Id, Inquiry_Update _inquiry);
        void DeleteInquiry(int id);
    }
}
