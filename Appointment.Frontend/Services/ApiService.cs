
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

    public void GetAll(string EndPoint)
    {
        var client = new HttpClient();
    }

}