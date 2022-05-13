using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookShopping.SpecflowTesting.Models
{
    internal class CartDetailModel
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderModel CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Count { get; set; }
    }
}
