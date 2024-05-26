
using Appointment.Frontend.Crud;
using Appointment.Globals.Enums;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Components.Base;

public abstract class BaseFormComponent<T> : ComponentBase
{
    [Parameter] public ViewType ViewType { get; set; }
    [CascadingParameter] public DynamicBaseView View {get; set;} = null!;
    protected T Entity {get; set;} = Activator.CreateInstance<T>();
}