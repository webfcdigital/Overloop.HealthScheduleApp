using Overloop.HealthScheduleApp.Domain.Entities;

namespace Overloop.HealthScheduleApp.Application.Interfaces;

public interface INotificationService
{
    Task NotifyConsultaAgendada(Consulta consulta);
}
