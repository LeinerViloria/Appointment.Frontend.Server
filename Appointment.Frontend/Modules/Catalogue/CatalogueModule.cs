
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class CatalogueModule : BaseModule<Catalogue>
{
    public override string PluralName {get; set;} = "Catálogos";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Catalogue.Name), typeof(Catalogue).GetProperty("Name")!.PropertyType}
    };
}