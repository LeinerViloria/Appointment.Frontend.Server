
using Configuration.Entities;

namespace Appointment.Frontend.Modules;

public class EmployeeModule : BaseModule<Employee>
{
    public override string PluralName {get; set;} = "Empleados";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Employee.Id), typeof(Employee).GetProperty("Id")!.PropertyType},
        {nameof(Employee.Name), typeof(Employee).GetProperty("Name")!.PropertyType},
        {nameof(Employee.Gender), typeof(Employee).GetProperty("Gender")!.PropertyType}
    };
}