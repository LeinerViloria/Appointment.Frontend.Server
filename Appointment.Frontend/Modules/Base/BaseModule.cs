using Appointment.Frontend.Interfaces;

namespace Appointment.Frontend.Modules;

public abstract class BaseModule<T> : IBaseModule where T : class
{
    public T Entity {get; set;} = Activator.CreateInstance<T>();
    public abstract string PluralName {get; set;}
    public abstract Dictionary<string, Type> GridColumns {get; set;}
}