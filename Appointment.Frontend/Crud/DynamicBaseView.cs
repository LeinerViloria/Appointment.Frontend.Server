
using Appointment.Frontend.Interfaces;
using Appointment.Frontend.Services;
using Appointment.Frontend.Utils;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Crud;

public abstract class DynamicBaseView : ComponentBase
{
    [Parameter] public string ViewRoute { get; set; } = null!;
    [Parameter] public int Rowid {get; set;}
    [Inject] public ApiService ApiService {get; set;} = null!;
    [Inject] public IServiceProvider ServiceProvider { get; set; } = null!;
    [Inject] public TranslatorService TranslatorService {get; set; } = null!;
    [Inject] public NavigationManager NavigationManager { get; set; } = null!;
    protected bool ViewIsReady {get; set;}
    protected bool RouteIsValid {get; set;}
    protected IBaseModule Module { get; set; } = null!;
    protected string LastViewRoute {get; set;} = null!;
    protected object Entity {get; set;} = null!;

    protected void SearchModule()
    {
        var Type = Utilities.SearchModule(ViewRoute);
        Module = (IBaseModule) ActivatorUtilities.CreateInstance(ServiceProvider, Type);
    }

    protected void SetEntity()
    {
        Entity = Module.GetType()
            .GetProperty("Entity")!
            .GetValue(Module)!;
    }
}