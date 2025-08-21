using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Overloop.HealthScheduleApp.Infrastructure.Repositories;

public class PacienteRepository : IPacienteRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName;

    public PacienteRepository(IAmazonDynamoDB dynamoDb, IConfiguration configuration)
    {
        _dynamoDb = dynamoDb;
        _tableName = configuration["TABLE_NAME"];
    }

    public async Task AddAsync(Paciente entity)
    {
        var request = new PutItemRequest
        {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"PACIENTE#{entity.Id}" } },
                { "SK", new AttributeValue { S = $"PACIENTE#{entity.Id}" } },
                { "Nome", new AttributeValue { S = entity.Nome } },
                { "Email", new AttributeValue { S = entity.Email } }
            }
        };
        await _dynamoDb.PutItemAsync(request);
    }

    public async Task<Paciente> GetByIdAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"PACIENTE#{id}" } },
                { "SK", new AttributeValue { S = $"PACIENTE#{id}" } }
            }
        };

        var response = await _dynamoDb.GetItemAsync(request);

        if (response.Item == null || !response.IsItemSet)
        {
            return null;
        }

        return MapToPaciente(response.Item);
    }

    public Task DeleteAsync(Paciente entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Paciente>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Paciente entity)
    {
        throw new NotImplementedException();
    }

    private Paciente MapToPaciente(Dictionary<string, AttributeValue> item)
    {
        return new Paciente
        {
            Id = Guid.Parse(item["PK"].S.Replace("PACIENTE#", "")),
            Nome = item["Nome"].S,
            Email = item["Email"].S
        };
    }
}