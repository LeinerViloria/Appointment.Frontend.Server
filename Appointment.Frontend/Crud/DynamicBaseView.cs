
using Appointment.Frontend.Interfaces;
using Appointment.Frontend.Services;
using Appointment.Frontend.Utils;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Crud;

public abstract class DynamicBaseView : ComponentBase
{
    [Parameter]
    public string ViewRoute { get; set; } = null!;
    [Inject] public ApiService ApiService {get; set;} = null!;
    [Inject] public IServiceProvider ServiceProvider { get; set; } = null!;
    protected bool ViewIsReady {get; set;}
    protected bool RouteIsValid {get; set;}
    protected IBaseModule Module { get; set; } = null!;

    protected void SearchModule()
    {
        var Type = Utilities.SearchModule(ViewRoute);
        Module = (IBaseModule) ActivatorUtilities.CreateInstance(ServiceProvider, Type);
    }
}