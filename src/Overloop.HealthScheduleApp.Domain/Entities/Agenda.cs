using Overloop.HealthScheduleApp.Domain.ValueObjects;

namespace Overloop.HealthScheduleApp.Domain.Entities;

public class Agenda
{
    public Guid Id { get; set; }
    public Guid MedicoId { get; set; }
    public List<Horario> HorariosDisponiveis { get; set; }

    public Medico Medico { get; set; }
}
