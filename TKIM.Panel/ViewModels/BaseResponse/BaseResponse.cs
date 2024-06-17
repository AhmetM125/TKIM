namespace TKIM.Panel.ViewModels.BaseResponse;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int? TotalCount { get; set; }

}
public class BaseResponseWithPagination<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public BaseResponseList<T> Data { get; set; }
    public int? TotalCount { get; set; }
}
public class BaseResponseList<T>
{
    public T? List { get; set; }
    public int? TotalCount { get; set; }
}
