using Overloop.HealthScheduleApp.Domain.Enums;

namespace Overloop.HealthScheduleApp.Application.DTOs;

public class MedicoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Especialidade Especialidade { get; set; }
}
