
using Appointment.Frontend.Components.Contract;
using Appointment.Globals.Enums;
using Configuration.Entities;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Modules;

public class ContractModule(IServiceProvider serviceProvider) : BaseModule<Contract>(serviceProvider)
{
    public override string PluralName {get; set;} = "Contratos";
    public override string SingularName {get; set;} = "Contrato";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Contract.Id), typeof(Contract).GetProperty("Id")!.PropertyType},
        {nameof(Contract.Employee), typeof(Contract).GetProperty("Employee")!.PropertyType},
        {nameof(Contract.InitialDate), typeof(Contract).GetProperty("InitialDate")!.PropertyType},
        {nameof(Contract.EndDate), typeof(Contract).GetProperty("EndDate")!.PropertyType}
    };

    public override RenderFragment GetForm(ViewType ViewType) => (builder) =>
    {
        builder.OpenComponent<ContractForm>(0);
        builder.AddAttribute(1, "ViewType", ViewType);
        builder.CloseComponent();
    };
}