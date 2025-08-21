using Overloop.HealthScheduleApp.Domain.Enums;

namespace Overloop.HealthScheduleApp.Application.DTOs;

public class CreateMedicoDto
{
    public string Nome { get; set; }
    public Especialidade Especialidade { get; set; }
}
