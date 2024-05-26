
using Appointment.Frontend.DTOS;
using Appointment.Frontend.Utils;
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

    public async Task<dynamic> GetAll(string Module, Type EntityType)
    {
        using var client = new HttpClient();

        var Url = EndPoints
            .Where(x => 
                x.EndPoints.Exists(y => string.Equals(y, Module, StringComparison.OrdinalIgnoreCase))
            ).Select(x => x.Url)
            .Single();

        var Request = await client.GetAsync($"{Url}api/{Module}/getData");

        if(!Request.IsSuccessStatusCode)
            return Enumerable.Empty<object>().ToList();

        string responseContent = await Request.Content.ReadAsStringAsync();

        var ListType = typeof(List<>)
            .MakeGenericType(EntityType);

        var Result = JsonConvert.DeserializeObject(responseContent, ListType) ?? Enumerable.Empty<object>().ToList();

        return Result;
    }

}