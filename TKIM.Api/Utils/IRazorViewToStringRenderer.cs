namespace TKIM.Api.Utils;

public interface IRazorViewToStringRenderer
{
    Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
}
