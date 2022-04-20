using System.Collections.Generic;

namespace eBookShopping.Web.Models

{
    public class CartViewModel
    {
        public CartHeaderViewModel CartHeader { get; set; }

        public IEnumerable<CartDetailViewModel> CartDetails { get; set; }
    }
}
