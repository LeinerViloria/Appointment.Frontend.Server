
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class ServiceModule : BaseModule<Service>
{
    public override string PluralName {get; set;} = "Servicios";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Service.Name), typeof(Service).GetProperty("Name")!.PropertyType},
        {nameof(Service.Price), typeof(Service).GetProperty("Price")!.PropertyType}
    };
}