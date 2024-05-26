
using Appointment.Frontend.DTOS;
using Appointment.Globals.Enums;
using Microsoft.AspNetCore.Components;

namespace Appointment.Frontend.Interfaces;

public interface IBaseModule
{
    string SingularName {get; set;}
    string PluralName { get; set;}
    Dictionary<string, Type> GridColumns {get; set;}
    Task<List<object>> GetData();
    Task<bool> Delete(object Rowid);
    RenderFragment GetForm(ViewType ViewType);
    string GetModuleName();
    Task<ApiResponse> Create();
    Task GetItem(object Rowid);
}