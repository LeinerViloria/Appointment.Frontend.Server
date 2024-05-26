
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Appointment.Frontend.Services;

public class TranslatorService(LocalDataService localDataService)
{
    public string? GetMessage(string Key)
    {
        var Json = (JObject) localDataService.GetLocalData<object>("translate.json");

        var Value = Json.GetValue(Key)?.ToString();

        return Value;
    }
}