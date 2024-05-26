
using System.Text;
using Appointment.Frontend.DTOS;
using Newtonsoft.Json;

namespace Appointment.Frontend.Services;

public class ApiService(IConfiguration configurationManager)
{
    List<ApiDataDTO> EndPoints {get; set;} = [];
    public bool EndPointIsSaved(string Name)
    {
        EndPoints = configurationManager.GetSection("ApiConfiguration")
            .Get<List<ApiDataDTO>>()!;

        var IsSaved = EndPoints.Exists(x => x.EndPoints.Exists(y => string.Equals(y, Name, StringComparison.OrdinalIgnoreCase)));

        return IsSaved;
    }

    private string GetEndpoint(string Module) => EndPoints
            .Where(x => 
                x.EndPoints.Exists(y => string.Equals(y, Module, StringComparison.OrdinalIgnoreCase))
            ).Select(x => x.Url)
            .Single();

    public async Task<List<T>> GetAll<T>(string Module)
    {
        using var client = new HttpClient();

        var Url = GetEndpoint(Module);

        var Request = await client.GetAsync($"{Url}api/{Module}/getData");

        if(!Request.IsSuccessStatusCode)
            return Enumerable.Empty<T>().ToList();

        string responseContent = await Request.Content.ReadAsStringAsync();

        var Result = JsonConvert.DeserializeObject<List<T>>(responseContent) ?? Enumerable.Empty<T>().ToList();

        return Result;
    }

    public async Task<bool> Delete(string Module, object Rowid)
    {
        using var client = new HttpClient();

        var Url = GetEndpoint(Module);

        var Request = await client.DeleteAsync($"{Url}api/{Module}/{Rowid}");

        if(!Request.IsSuccessStatusCode)
            return false;

        string responseContent = await Request.Content.ReadAsStringAsync();

        var Result = !string.IsNullOrEmpty(responseContent) && responseContent != "0";

        return Result;
    }

    public async Task<ApiResponse> Create(string Module, dynamic Obj)
    {
        using var client = new HttpClient();

        var Url = GetEndpoint(Module);

        var ValueContent = JsonConvert.SerializeObject(Obj);

        var Content = new StringContent(ValueContent, Encoding.UTF8, "application/json");

        var Request = await client.PostAsync($"{Url}api/{Module}/", Content)
            .ConfigureAwait(true);

        string responseContent = await Request.Content.ReadAsStringAsync();

        var ApiResponse = new ApiResponse(){
            Success = Request.IsSuccessStatusCode,
            Result = responseContent
        };

        return ApiResponse;
    }

    public async Task<ApiResponse> Update(string Module, dynamic Obj)
    {
        using var client = new HttpClient();

        var Url = GetEndpoint(Module);

        var ValueContent = JsonConvert.SerializeObject(Obj);

        var Content = new StringContent(ValueContent, Encoding.UTF8, "application/json");

        var Request = await client.PutAsync($"{Url}api/{Module}/", Content)
            .ConfigureAwait(true);

        string responseContent = await Request.Content.ReadAsStringAsync();

        var ApiResponse = new ApiResponse(){
            Success = Request.IsSuccessStatusCode,
            Result = responseContent
        };

        return ApiResponse;
    }

    public async Task<T?> GetItem<T>(string Module, object Rowid) where T : class
    {
        using var client = new HttpClient();

        var Url = GetEndpoint(Module);

        var Request = await client.GetAsync($"{Url}api/{Module}/getData?Rowid={Rowid}");

        if(!Request.IsSuccessStatusCode)
            return default;

        string responseContent = await Request.Content.ReadAsStringAsync();

        var Result = JsonConvert.DeserializeObject<List<T>>(responseContent) ?? [];

        var Item = Result.FirstOrDefault();

        return Item;
    }

}