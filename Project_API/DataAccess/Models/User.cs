using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API_Project.DataAccess.Models;

namespace application.DataAccess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // الرقم التعريفي للمستخدم (Primary Key)
        [Required]
        [StringLength(20)]
        public string F_Name { get; set; } // اسم المستخدم
        [Required]
        [StringLength(20)]
        public string L_Name { get; set; } // اسم المستخدم
        public string FullName { get; private set; } // سيتم حسابها من قاعدة البيانات // اسم المستخدم
        [EmailAddress]
        [Required]

        public string Email { get; set; } // البريد الإلكتروني
        [Required]

        public string Password { get; set; } // كلمة المرور
        [Required]

        public string PhoneNumber { get; set; } // رقم التليفون

        //[Required]
        //public string Password
        //{
        //    get => _passwordHash;
        //    set => _passwordHash = BCrypt.Net.BCrypt.HashPassword(value); // تشفير كلمة المرور
        //}



        //public string Role { get; set; } // دور المستخدم (بائع، مشتري، مدير)
        public string? Address { get; set; } // عنوان المستخدم
        public string ProfilePicture { get; set; } // صورة الملف الشخصي
        //public string UserType { get; set; } // نوع المستخدم (بائع، مشتري، وكيل، مدير)

        // العلاقات
        public virtual IEnumerable<Property> Properties { get; set; } // العقارات التي يمتلكها المستخدم
        public IEnumerable<Inquiry> Inquiries { get; set; } // الاستفسارات المرسلة من قبل المستخدم

        //public ICollection<Review> Reviews { get; set; } // المراجعات التي كتبها المستخدم
        //public ICollection<Transaction> BuyerTransactions { get; set; } // المعاملات التي قام بها المستخدم كمشتري
        //public ICollection<Transaction> SellerTransactions { get; set; } // المعاملات التي قام بها المستخدم كبائع
    }


}
