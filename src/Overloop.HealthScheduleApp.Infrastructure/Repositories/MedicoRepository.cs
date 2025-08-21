using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Overloop.HealthScheduleApp.Domain.Entities;
using Overloop.HealthScheduleApp.Domain.Interfaces;
using Overloop.HealthScheduleApp.Domain.Enums;
using Microsoft.Extensions.Configuration;

namespace Overloop.HealthScheduleApp.Infrastructure.Repositories;

public class MedicoRepository : IMedicoRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly string _tableName;

    public MedicoRepository(IAmazonDynamoDB dynamoDb, IConfiguration configuration)
    {
        _dynamoDb = dynamoDb;
        _tableName = configuration["TABLE_NAME"];
    }

    public async Task AddAsync(Medico entity)
    {
        var request = new PutItemRequest
        {
            TableName = _tableName,
            Item = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"MEDICO#{entity.Id}" } },
                { "SK", new AttributeValue { S = $"MEDICO#{entity.Id}" } },
                { "Nome", new AttributeValue { S = entity.Nome } },
                { "Especialidade", new AttributeValue { S = entity.Especialidade.ToString() } }
            }
        };
        await _dynamoDb.PutItemAsync(request);
    }

    public async Task<Medico> GetByIdAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = _tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "PK", new AttributeValue { S = $"MEDICO#{id}" } },
                { "SK", new AttributeValue { S = $"MEDICO#{id}" } }
            }
        };

        var response = await _dynamoDb.GetItemAsync(request);

        if (response.Item == null || !response.IsItemSet)
        {
            return null;
        }

        return MapToMedico(response.Item);
    }

    public Task DeleteAsync(Medico entity)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Medico>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Medico entity)
    {
        throw new NotImplementedException();
    }

    private Medico MapToMedico(Dictionary<string, AttributeValue> item)
    {
        return new Medico
        {
            Id = Guid.Parse(item["PK"].S.Replace("MEDICO#", "")),
            Nome = item["Nome"].S,
            Especialidade = Enum.Parse<Especialidade>(item["Especialidade"].S) 
        };
    }
}