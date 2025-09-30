using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Vizallas.Models
{
    public class Adatok
    {
        
        public int Id { get; set; }
        public string datum { get; set; }
        public int vizallas { get; set; }
        public string varos { get; set; }
        public string folyo { get; set; }
    }
}
