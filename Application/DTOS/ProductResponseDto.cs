namespace Application.DTOS
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Sku { get; set; } 
        public string Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime? UpdatedAtUtc { get; set; }

    }
}
