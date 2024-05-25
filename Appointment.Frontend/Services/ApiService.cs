
using Appointment.Frontend.DTOS;
using Appointment.Frontend.Utils;
using Newtonsoft.Json;

namespace Appointment.Frontend.Services;

public class ApiService
{
    List<ApiDataDTO> EndPoints {get; set;} = [];
    public bool EndPointIsSaved(string Name)
    {
        var Item = Utilities.SearchFile("ApiData.json");

        if(EndPoints.Count == 0)
        {
            var Data = JsonConvert.DeserializeObject<List<ApiDataDTO>>(Item)!;
            EndPoints = Data;
        }

        var IsSaved = EndPoints.Exists(x => x.EndPoints.Exists(y => string.Equals(y, Name, StringComparison.OrdinalIgnoreCase)));

        return IsSaved;
    }

    public void GetAll(string EndPoint)
    {
        var client = new HttpClient();
    }

}