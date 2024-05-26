
namespace Appointment.Frontend.DTOS;

public record ApiResponse
{
    public bool Success {get; set;}
    public string Result {get; set;} = null!;
}