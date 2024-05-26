using Appointment.Frontend.DTOS;
using Appointment.Frontend.Interfaces;
using Appointment.Frontend.Services;
using Appointment.Globals.Enums;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Modules;

public abstract class BaseModule<T>(IServiceProvider serviceProvider) : IBaseModule where T : class
{
    public T Entity {get; set;} = Activator.CreateInstance<T>();
    public abstract string PluralName {get; set;}
    public abstract string SingularName {get; set;}
    public abstract Dictionary<string, Type> GridColumns {get; set;}
    public string ModuleName => GetType().Name.Replace("Module", "");
    protected ApiService ApiService => GetApiService();

    public abstract RenderFragment GetForm(ViewType ViewType);

    public string GetModuleName() => ModuleName;

    protected ApiService GetApiService() => serviceProvider.GetService<ApiService>()!;

    public virtual async Task<List<object>> GetData()
    {
        var Result = await ApiService.GetAll<T>(ModuleName);
        return Result.Cast<object>()
            .ToList();
    }

    public virtual async Task<bool> Delete(object Rowid)
    {
        var Result = await ApiService.Delete(ModuleName, Rowid);
        return Result;
    }

    public virtual async Task<ApiResponse> Save()
    {
        var Rowid = typeof(T).GetProperty("Rowid")?
            .GetValue(Entity);

        ApiResponse Request;

        if (Rowid is null || Rowid.Equals(0))
            Request = await ApiService.Create(ModuleName, Entity);
        else
            Request = await ApiService.Update(ModuleName, Entity);

        return Request;
    }

    public virtual async Task GetItem(object Rowid)
    {
        Entity = await ApiService.GetItem<T>(ModuleName, Rowid) ?? Activator.CreateInstance<T>();
    }
}