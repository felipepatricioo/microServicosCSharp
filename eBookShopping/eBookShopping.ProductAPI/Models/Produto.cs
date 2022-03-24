using eBookShopping.ProductAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBookShopping.ProductAPI.Models
{
    [Table("Books")]
    public class Produto : BaseEntity
    {
        [Column("Name")]
        [Required]
        [StringLength(150)]
       public string Name { get; set; }

        [Column("Price")]
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [Column("Description")]
        [StringLength(500)]
        public string Description { get; set; }

        [Column("Category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("Image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
