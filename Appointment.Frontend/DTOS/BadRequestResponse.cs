
namespace Appointment.Frontend.DTOS;

public record BadRequestResponse
{
    public string Title {get; set;} = null!;
    public int Status {get; set;}
    public ErrorDetail Errors {get; set;} = new();
}

public record ErrorDetail
{
    public List<string> Name {get; set;} = [];
}