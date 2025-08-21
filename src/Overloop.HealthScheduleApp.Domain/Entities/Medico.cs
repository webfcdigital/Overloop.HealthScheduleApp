using Overloop.HealthScheduleApp.Domain.Enums;

namespace Overloop.HealthScheduleApp.Domain.Entities;

public class Medico
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Especialidade Especialidade { get; set; }
}
