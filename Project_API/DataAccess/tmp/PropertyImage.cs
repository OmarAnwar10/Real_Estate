using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
