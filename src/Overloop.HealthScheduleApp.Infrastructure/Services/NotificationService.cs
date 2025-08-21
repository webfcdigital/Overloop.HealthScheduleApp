using System.Text.Json;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Overloop.HealthScheduleApp.Application.Interfaces;
using Overloop.HealthScheduleApp.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Overloop.HealthScheduleApp.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly IAmazonSimpleNotificationService _sns;
    private readonly string _topicArn;

    public NotificationService(IAmazonSimpleNotificationService sns, IConfiguration configuration)
    {
        _sns = sns;
        _topicArn = configuration["SNS_TOPIC_ARN"];
    }

    public async Task NotifyConsultaAgendada(Consulta consulta)
    {
        var message = JsonSerializer.Serialize(consulta);
        var request = new PublishRequest
        {
            TopicArn = _topicArn,
            Message = message
        };

        await _sns.PublishAsync(request);
    }
}