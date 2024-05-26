
using Appointment.Frontend.Components.Service;
using Appointment.Globals.Enums;
using Configuration.Entities;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Modules;

public class ServiceModule(IServiceProvider serviceProvider) : BaseModule<Service>(serviceProvider)
{
    public override string PluralName {get; set;} = "Servicios";
    public override string SingularName {get; set;} = "Servicio";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Service.Name), typeof(Service).GetProperty("Name")!.PropertyType},
        {nameof(Service.Price), typeof(Service).GetProperty("Price")!.PropertyType},
        {nameof(Service.Status), typeof(Service).GetProperty("Status")!.PropertyType}
    };

    public override RenderFragment GetForm(ViewType ViewType) => (builder) =>
    {
        builder.OpenComponent<ServiceForm>(0);
        builder.AddAttribute(1, "ViewType", ViewType);
        builder.CloseComponent();
    };
}