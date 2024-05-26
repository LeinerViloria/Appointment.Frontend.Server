
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class ServiceModule(IServiceProvider serviceProvider) : BaseModule<Service>(serviceProvider)
{
    public override string PluralName {get; set;} = "Servicios";
    public override string SingularName {get; set;} = "Servicio";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Service.Name), typeof(Service).GetProperty("Name")!.PropertyType},
        {nameof(Service.Price), typeof(Service).GetProperty("Price")!.PropertyType}
    };
}