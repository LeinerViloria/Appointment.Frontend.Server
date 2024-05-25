using System.Collections.Concurrent;
using Appointment.Frontend.Utils;
using Newtonsoft.Json;

namespace Appointment.Frontend.Services;

public class LocalDataService
{
    private ConcurrentDictionary<string, dynamic> Data {get; set;} = [];

    public T GetLocalData<T>(string FileName)
    {
        var Found = Data.TryGetValue(FileName, out var Result);

        if(Found)
            return Result!;

        var Item = Utilities.SearchFile(FileName);

        if(string.IsNullOrEmpty(Item))
            return default(T)!;

        Result = JsonConvert.DeserializeObject<T>(Item)!;

        Data.TryAdd(FileName, Result);

        return Result;
    }
}