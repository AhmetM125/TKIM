using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace TKIM.Panel.Services.Base;
public class BaseService
{
    protected string ApiName { get; set; }
    protected HttpClient _httpClient { get; init; }

    public BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> HandleReadResponse<T>(string requestUrl)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{ApiName}/{requestUrl}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return result ?? default(T);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }
        catch (Exception)
        {
            Console.WriteLine("Error");
            throw;
        }
    }
    public async Task HandlePostResponse<T>(string requestUrl, T entity)
    {
        try
        {
            HttpContent content = new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{ApiName}/{requestUrl}", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception(errorMessage);
            }
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    //public async Task<T> GetByIdAsync(int id)
    //{
    //    var response = await _httpClient.GetAsync($"{id}");
    //    if (response.IsSuccessStatusCode)
    //    {
    //        var result = await response.Content.ReadAsStringAsync();
    //        return JsonConvert.DeserializeObject<T>(result);
    //    }
    //    return null;
    //}

    //public async Task<bool> AddAsync(T entity)
    //{
    //    var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
    //    var response = await _httpClient.PostAsync("", content);
    //    return response.IsSuccessStatusCode;
    //}

    //public async Task<bool> UpdateAsync(T entity)
    //{
    //    var content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
    //    var response = await _httpClient.PutAsync("", content);
    //    return response.IsSuccessStatusCode;
    //}

    //public async Task<bool> RemoveAsync(int id)
    //{
    //    var response = await _httpClient.DeleteAsync($"{id}");
    //    return response.IsSuccessStatusCode;
    //}
}
