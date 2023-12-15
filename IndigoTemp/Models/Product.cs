using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndigoTemp.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public string? ImgUrl {  get; set; }
		public bool IsDeleted { get; set; }
		[NotMapped]
        public IFormFile? Photo { get; set; }
    }
}
