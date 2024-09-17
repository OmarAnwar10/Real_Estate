using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Services.Models.Inquiry
{
    public class Inquiry_Create
    {
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public string? PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
