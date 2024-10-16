namespace CleanArchitecture.Application.Dtos;
public class SearchDto
{
    public required string GlobalFilter { get; set; } = string.Empty;
    public required string SearchFilter { get; set; } = string.Empty;
    public required string SearchFilterValues { get; set; } = string.Empty;
    public int First { get; set; }
    public int Rows { get; set; }
    public required string SortField { get; set; } = string.Empty;
    public int? SortOrder { get; set; }
    public string? FileType { get; set; }
    public string? ToEmail { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}
