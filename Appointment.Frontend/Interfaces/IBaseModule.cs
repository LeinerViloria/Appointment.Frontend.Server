
namespace Appointment.Frontend.Interfaces;

public interface IBaseModule
{
    string PluralName { get; set;}
    Dictionary<string, Type> GridColumns {get; set;}
    Task<List<object>> GetData();
    Task<bool> Delete(object Rowid);
}