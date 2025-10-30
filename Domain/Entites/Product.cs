
using System.ComponentModel.DataAnnotations;

namespace Domain.Entites
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }  
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; } 
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }
        public bool IsDeleted { get; set; }  

    }
}
