using Appointment.Frontend.Interfaces;

namespace Appointment.Frontend.Modules;

public abstract class BaseModule<T> : IBaseModule<T> where T : class
{
    public T Entity {get; set;} = default!;
    public abstract string Name {get; set;}
}