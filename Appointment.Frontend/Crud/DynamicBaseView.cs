
using Appointment.Frontend.Interfaces;
using Appointment.Frontend.Services;
using Appointment.Frontend.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

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
    public object Entity {get; set;} = null!;
    public string FormId {get; set;} = $"{Guid.NewGuid()}";
    public EditContext EditFormContext;
    protected bool IsBusy {get; set;}

    protected void SearchModule()
    {
        var Type = Utilities.SearchModule(ViewRoute);
        Module = (IBaseModule) ActivatorUtilities.CreateInstance(ServiceProvider, Type);
    }

    protected void SetEntity()
    {
        EditFormContext ??= new EditContext(this);
        Entity = Module.GetType()
            .GetProperty("Entity")!
            .GetValue(Module)!;
    }

    protected void HandleInvalidSubmit()
    {

    }

    protected async Task HandleValidSubmit()
    {
        IsBusy = true;
        var Result = EditFormContext.Validate();
        
    }
}