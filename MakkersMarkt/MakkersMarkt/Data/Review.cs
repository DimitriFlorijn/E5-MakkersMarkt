using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakkersMarkt.Data
{
    public class Review { 
        public int Id { get; set; }
        public int OrderId { get; set; } 
        public float Rating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; } }

}
