using System.Collections;
using System.Text;
using System.Text.Json;
using TKIM.Panel.Services.Abstract;
using TKIM.Panel.Services.Base;
using TKIM.Panel.ViewModels.BaseResponse;
using TKIM.Panel.ViewModels.Product;

namespace TKIM.Panel.Services.Concrete;

public class ProductService : BaseService, IProductService
{
    public ProductService(HttpClient httpClient) : base(httpClient)
    {
        ApiName = "v1/Product";
    }

    public async Task CreateProductAsync(ProductInsertRequest model, List<FileDetail> files, bool HasBestBeforeDate)
    {
        if (HasBestBeforeDate)
            model.BestBeforeDate = null;

        var requestProduct = new RequestProduct
        {
            Model = model,
            Files = files
        };

        var jsonRequest = JsonSerializer.Serialize(requestProduct);
        var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{ApiName}/Create", content);

        if (!response.IsSuccessStatusCode)
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            throw new Exception(errorMessage);
        }
    }

    public Task<ProductModifyResponse?> GetProductById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductListResponse>?> GetProductList()
     => await HandleReadResponse<List<ProductListResponse>>("GetList");

    public async Task<BaseResponseWithPagination<List<ProductListPosResponse>>> ProductListForPos(string searchText, int currentPage)
     => await HandleReadResponseWithPagination<List<ProductListPosResponse>>($"GetListForPos?searchText={searchText}&currentPage={currentPage}");
}
