using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpustecCodeTest2.Models
{
    public class SalesMaster
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalQuantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
