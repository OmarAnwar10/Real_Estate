using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Inquiry
    {
        public int Id { get; set; } // الرقم التعريفي للاستفسار (Primary Key)
        public int UserId { get; set; } // الرقم التعريفي للمستخدم اللي بعت الاستفسار (Foreign Key)
        public int PropertyId { get; set; } // الرقم التعريفي للعقار اللي عليه الاستفسار (Foreign Key)
        public string Message { get; set; } // الرسالة أو الاستفسار
        public DateTime DateSent { get; set; } // تاريخ إرسال الاستفسار
        public User User { get; set; } // المستخدم اللي بعت الاستفسار
        public Property Property { get; set; } // العقار اللي عليه الاستفسار
    }
}
