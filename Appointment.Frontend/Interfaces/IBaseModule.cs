
namespace Appointment.Frontend.Interfaces;

public interface IBaseModule<T> where T : class
{
    string Name { get; set;}
    T Entity {get; set;}
}