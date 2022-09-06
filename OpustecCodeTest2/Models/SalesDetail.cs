using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpustecCodeTest2.Models
{
    public class SalesDetail
    {
        public int Id { get; set; }
        public int MyProperty { get; set; }

        public int? ProductId { get; set; }
        public Product Product { get; set; }

        public int? SalesMasterId { get; set; }
        public SalesMaster SalesMaster { get; set; }

    }
}
