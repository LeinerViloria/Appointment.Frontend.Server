
using Appointment.Globals.Enums;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Components.Base;

public abstract class BaseFormComponent : ComponentBase
{
    [Parameter] public ViewType ViewType { get; set; }
}