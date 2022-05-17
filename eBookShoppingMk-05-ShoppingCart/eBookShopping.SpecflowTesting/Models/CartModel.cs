using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBookShopping.SpecflowTesting.Models
{
    internal class CartModel
    {
        public CartHeaderModel CartHeader { get; set; }

        public IEnumerable<CartDetailModel> CartDetails { get; set; }
    }
}
