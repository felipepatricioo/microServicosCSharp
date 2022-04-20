using eBookShopping.CartAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookShopping.CartAPI.Models
{
    [Table("cart_detail")]
    public class CartDetail: BaseEntity
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public CartHeader CartHeader { get; set; }
        public long ProductId { get; set; }
        [ForeignKey("ProductId")]
        public CartHeader Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
