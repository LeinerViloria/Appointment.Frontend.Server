
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class CatalogueModule : BaseModule<Catalogue>
{
    public override string PluralName {get; set;} = "Catálogos";
}