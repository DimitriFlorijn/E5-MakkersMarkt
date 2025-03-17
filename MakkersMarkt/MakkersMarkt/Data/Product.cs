using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakkersMarkt.Data
{
    public class Product { 
        public int Id { get; set; }
        public int MakerId { get; set; }
        public int TypeMaterialId { get; set; }
        public int SpecificationId { get; set; }
        public double Price { get; set; }
        public string imageUrl { get; set; }    
        public string ProductionTime { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } 
    }

}
