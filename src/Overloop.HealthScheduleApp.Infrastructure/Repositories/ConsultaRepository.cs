using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;
using Overloop.HealthScheduleApp.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Overloop.HealthScheduleApp.Infrastructure.Repositories;

public class ConsultaRepository : IConsultaRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName;

    public ConsultaRepository(IAmazonDynamoDB dynamoDb, IConfiguration configuration)
    {
        _dynamoDb = dynamoDb;
        _tableName = configuration["TABLE_NAME"];
    }

    public async Task AddAsync(Consulta entity)
    {
        var request = new PutItemRequest
        {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"CONSULTA#{entity.Id}" } },
                { "SK", new AttributeValue { S = $"CONSULTA#{entity.Id}" } },
                { "PacienteId", new AttributeValue { S = entity.PacienteId.ToString() } },
                { "MedicoId", new AttributeValue { S = entity.MedicoId.ToString() } },
                { "DataHora", new AttributeValue { S = entity.DataHora.ToString("o") } },
                { "Status", new AttributeValue { S = entity.Status.ToString() } }
            }
        };
        await _dynamoDb.PutItemAsync(request);
    }

    public async Task<Consulta> GetByIdAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"CONSULTA#{id}" } },
                { "SK", new AttributeValue { S = $"CONSULTA#{id}" } }
            }
        };

        var response = await _dynamoDb.GetItemAsync(request);

        if (response.Item == null || !response.IsItemSet)
        {
            return null;
        }

        return MapToConsulta(response.Item);
    }

    public Task DeleteAsync(Consulta entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Consulta>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Consulta entity)
    {
        throw new NotImplementedException();
    }

    private Consulta MapToConsulta(Dictionary<string, AttributeValue> item)
    {
        return new Consulta
        {
            Id = Guid.Parse(item["PK"].S.Replace("CONSULTA#", "")),
            PacienteId = Guid.Parse(item["PacienteId"].S),
            MedicoId = Guid.Parse(item["MedicoId"].S),
            DataHora = DateTime.Parse(item["DataHora"].S),
            Status = Enum.Parse<ConsultaStatus>(item["Status"].S)
        };
    }
}