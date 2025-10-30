namespace Application.DTOS
{
    public class PagedResult()
    {
       public IReadOnlyList<ProductResponseDto> productsDtos {  get; set; }

       public int TotalCount { get; set; }

       public  int PageIndex{  get; set; }

       public int PageSize{ get; set; }

    }
}
