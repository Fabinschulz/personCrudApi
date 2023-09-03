namespace Crud.API.src.Domain.Entities
{
    public class ListDataPagination<T>
    {
            public int Page { get; set; }
            public int TotalPages { get; set; } = 0;
            public int TotalItems { get; set; }
            public List<T> Data { get; set; }
    }
}
