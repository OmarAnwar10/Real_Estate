namespace API_Project.DataAccess.DTOs
{
    public class InquiryDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public UserDto User { get; set; }
        public PropertyDto Property { get; set; }
    }

}
