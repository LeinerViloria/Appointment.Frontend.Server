
using Appointment.Globals.Enums;
using Configuration.Entities;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Modules;

public class CatalogueModule(IServiceProvider serviceProvider) : BaseModule<Catalogue>(serviceProvider)
{
    public override string PluralName {get; set;} = "Catálogos";
    public override string SingularName {get; set;} = "Catálogo";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Catalogue.Name), typeof(Catalogue).GetProperty("Name")!.PropertyType}
    };

    public override RenderFragment GetForm(ViewType ViewType) => (builder) =>
    {
        
    };
}