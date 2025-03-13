using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakkersMarkt.Data
{
    public class Order { 
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedAt { get; set; } 
    }

}
