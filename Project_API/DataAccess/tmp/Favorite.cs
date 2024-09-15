using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Favorite
    {
        public int Id { get; set; } // الرقم التعريفي للمفضلة (Primary Key)
        public int UserId { get; set; } // الرقم التعريفي للمستخدم (Foreign Key)
        public int PropertyId { get; set; } // الرقم التعريفي للعقار (Foreign Key)
        public User User { get; set; } // المستخدم الذي أضاف العقار للمفضلة
        public Property Property { get; set; } // العقار الذي تمت إضافته للمفضلة
    }
}
