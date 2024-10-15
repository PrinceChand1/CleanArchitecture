namespace CleanArchitecture.Application.Dtos;
public class PageCountDto
{
    public int PageCount { get; set; } = 0;
    public int PageSize { get; set; } = 0;
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
