using Overloop.HealthScheduleApp.Domain.Enums;

namespace Overloop.HealthScheduleApp.Domain.Entities;

public class Consulta
{
    public Guid Id { get; set; }
    public Guid PacienteId { get; set; }
    public Guid MedicoId { get; set; }
    public DateTime DataHora { get; set; }
    public ConsultaStatus Status { get; set; }

    public Paciente Paciente { get; set; }
    public Medico Medico { get; set; }
}
