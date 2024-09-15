using application.DataAccess.Models;

namespace API_Project.DataAccess.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
