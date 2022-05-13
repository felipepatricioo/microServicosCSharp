using eBookShopping.SpecflowTesting.Model;
using eBookShopping.SpecflowTesting.Models;

namespace eBookShopping.SpecflowTesting
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }

        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
