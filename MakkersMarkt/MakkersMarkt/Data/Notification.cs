﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakkersMarkt.Data
{
    public class Notification { 
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } 
        public DateTime CreatedAt { get; set; } }

}
