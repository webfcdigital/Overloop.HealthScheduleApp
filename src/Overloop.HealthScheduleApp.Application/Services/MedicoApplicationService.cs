using Overloop.HealthScheduleApp.Application.DTOs;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;

namespace Overloop.HealthScheduleApp.Application.Services;

public class MedicoApplicationService : IMedicoApplicationService
{
    private readonly IMedicoRepository _medicoRepository;

    public MedicoApplicationService(IMedicoRepository medicoRepository)
    {
        _medicoRepository = medicoRepository;
    }

    public async Task<MedicoDto> CreateAsync(CreateMedicoDto createMedicoDto)
    {
        var medico = new Medico
        {
            Id = Guid.NewGuid(),
            Nome = createMedicoDto.Nome,
            Especialidade = createMedicoDto.Especialidade
        };

        await _medicoRepository.AddAsync(medico);

        return new MedicoDto
        {
            Id = medico.Id,
            Nome = medico.Nome,
            Especialidade = medico.Especialidade
        };
    }

    public async Task<MedicoDto> GetByIdAsync(Guid id)
    {
        var medico = await _medicoRepository.GetByIdAsync(id);
        if (medico == null)
        {
            return null;
        }

        return new MedicoDto
        {
            Id = medico.Id,
            Nome = medico.Nome,
            Especialidade = medico.Especialidade
        };
    }
}
