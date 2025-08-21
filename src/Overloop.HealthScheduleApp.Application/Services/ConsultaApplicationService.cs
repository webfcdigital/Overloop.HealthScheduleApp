using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;

namespace Overloop.HealthScheduleApp.Application.Services;

public class ConsultaApplicationService : IConsultaApplicationService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly INotificationService _notificationService;

    public ConsultaApplicationService(IConsultaRepository consultaRepository, INotificationService notificationService)
    {
        _consultaRepository = consultaRepository;
        _notificationService = notificationService;
    }

    public async Task<ConsultaDto> CreateAsync(CreateConsultaDto createConsultaDto)
    {
        var consulta = new Consulta
        {
            Id = Guid.NewGuid(),
            PacienteId = createConsultaDto.PacienteId,
            MedicoId = createConsultaDto.MedicoId,
            DataHora = createConsultaDto.DataHora,
            Status = Domain.Enums.ConsultaStatus.Agendada
        };

        await _consultaRepository.AddAsync(consulta);

        await _notificationService.NotifyConsultaAgendada(consulta);

        return new ConsultaDto
        {
            Id = consulta.Id,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            DataHora = consulta.DataHora,
            Status = consulta.Status
        };
    }

    public async Task<ConsultaDto> GetByIdAsync(Guid id)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id);
        if (consulta == null)
        {
            return null;
        }

        return new ConsultaDto
        {
            Id = consulta.Id,
            PacienteId = consulta.PacienteId,
            MedicoId = consulta.MedicoId,
            DataHora = consulta.DataHora,
            Status = consulta.Status
        };
    }
}
