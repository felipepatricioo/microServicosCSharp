
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookShopping.SpecflowTesting.Models
{
    [Table("cart_detail")]
    public class CartDetail
    {
        public long CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}
