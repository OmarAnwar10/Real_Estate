using System.ComponentModel.DataAnnotations;

namespace API_Project.DataAccess.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }  
        [Required]
        public string F_Name { get; set; }
        [Required]
        public string L_Name { get; set; }
        public string FullName { get { return F_Name + " " + L_Name; } }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
    }


}
