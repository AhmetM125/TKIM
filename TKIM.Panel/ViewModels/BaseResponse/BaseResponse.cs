namespace TKIM.Panel.ViewModels.BaseResponse;

public class BaseResponse<T> where T : class
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
}
