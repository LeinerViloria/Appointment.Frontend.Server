using Appointment.Frontend.Interfaces;

namespace Appointment.Frontend.Modules;

public abstract class BaseModule<T> : IBaseModule where T : class
{
    public T Entity {get; set;} = default!;
    public abstract string PluralName {get; set;}
}