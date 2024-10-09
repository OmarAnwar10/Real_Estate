using MVC_Project.Models;

namespace MVC_Project.ViewModel
{
    public class PropertyViewModel
    {
        public IEnumerable<Properties_List> Properties { get; set; }
        public IEnumerable<City_Get> Cites { get; set; }
    }
}
