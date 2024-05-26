
using Appointment.Frontend.Crud;
using Appointment.Frontend.Services;
using Appointment.Globals.Enums;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Components.Base;

public abstract class BaseFormComponent<T> : ComponentBase
{
    [Parameter] public ViewType ViewType { get; set; }
    [Inject] public TranslatorService TranslatorService { get; set; } = null!;
    [CascadingParameter] public DynamicBaseView View {get; set;} = null!;
    protected T Entity {get; set;} = default!;

    protected void InitEntity()
    {
        Entity = (T) View.Entity;
    }

    protected override void OnInitialized()
    {
        InitEntity();
        base.OnInitialized();
    }
}