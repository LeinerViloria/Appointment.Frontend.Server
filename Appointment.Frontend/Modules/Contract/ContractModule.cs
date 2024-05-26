
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class ContractModule : BaseModule<Contract>
{
    public override string PluralName {get; set;} = "Contratos";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Contract.Id), typeof(Contract).GetProperty("Id")!.PropertyType},
        {nameof(Contract.Employee), typeof(Contract).GetProperty("Employee")!.PropertyType},
        {nameof(Contract.InitialDate), typeof(Contract).GetProperty("InitialDate")!.PropertyType},
        {nameof(Contract.EndDate), typeof(Contract).GetProperty("EndDate")!.PropertyType}
    };
}