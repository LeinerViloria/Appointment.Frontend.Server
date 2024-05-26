using Appointment.Frontend.Interfaces;
using Appointment.Frontend.Services;

namespace Appointment.Frontend.Modules;

public abstract class BaseModule<T>(IServiceProvider serviceProvider) : IBaseModule where T : class
{
    public T Entity {get; set;} = Activator.CreateInstance<T>();
    public abstract string PluralName {get; set;}
    public abstract Dictionary<string, Type> GridColumns {get; set;}

    public virtual async Task<List<object>> GetData()
    {
        var ApiService = serviceProvider.GetService<ApiService>()!;
        var Result = await ApiService.GetAll<T>(GetType().Name.Replace("Module", ""), Entity.GetType());

        return Result.Cast<object>()
            .ToList();
    }
}