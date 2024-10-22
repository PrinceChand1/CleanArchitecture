namespace CleanArchitecture.Application.Dtos;
public class Result<T>
{
    public T Data { get; set; }
    public bool Success { get; set; }
    public string Error { get; set; }
    public int ErrorCode { get; set; }
    public Pagination Pagination { get; set; }
    public Dictionary<string, string> MetaData { get; set; }
}
public class Pagination
{
    public int TotalRecordCount { get; set; }
    public int Pageno { get; set; }
}