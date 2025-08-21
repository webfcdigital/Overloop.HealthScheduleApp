namespace Overloop.HealthScheduleApp.Application.DTOs;

public class CreateConsultaDto
{
    public Guid PacienteId { get; set; }
    public Guid MedicoId { get; set; }
    public DateTime DataHora { get; set; }
}
