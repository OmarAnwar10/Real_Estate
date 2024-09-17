using application.DataAccess.Models;

namespace _DataAccess.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
