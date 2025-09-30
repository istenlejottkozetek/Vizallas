using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Vizallas.Models
{
    public class Adatok
    {
        
        public int Id { get; set; }
        public int datum { get; set; }
        public int vizallas { get; set; }
        public int varos { get; set; }
        public int folyo { get; set; }
    }
}
