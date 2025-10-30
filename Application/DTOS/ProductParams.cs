

namespace Application.DTOS
{
    public class ProductParams
    {
        public string Search {  get; set; }

        public int PageSize { get; set; } = 10;

        public int PageIndex { get; set; } = 1;

        public bool IncludeDeleted=false;
    }
}
