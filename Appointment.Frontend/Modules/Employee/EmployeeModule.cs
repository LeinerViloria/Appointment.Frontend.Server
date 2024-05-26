
using Appointment.Globals.Enums;
using Configuration.Entities;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Modules;

public class EmployeeModule(IServiceProvider serviceProvider) : BaseModule<Employee>(serviceProvider)
{
    public override string PluralName {get; set;} = "Empleados";
    public override string SingularName {get; set;} = "Empleado";
    public override Dictionary<string, Type> GridColumns {get; set;} = new()
    {
        {nameof(Employee.Id), typeof(Employee).GetProperty("Id")!.PropertyType},
        {nameof(Employee.Name), typeof(Employee).GetProperty("Name")!.PropertyType},
        {nameof(Employee.Gender), typeof(Employee).GetProperty("Gender")!.PropertyType}
    };

    public override RenderFragment GetForm(ViewType ViewType) => (builder) =>
    {
        
    };
}