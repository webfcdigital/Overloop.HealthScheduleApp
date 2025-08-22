using Amazon.Lambda.AspNetCoreServer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting; // Required for IHostBuilder
using System.IO; // Required for Directory.GetCurrentDirectory()

namespace Overloop.HealthScheduleApp.Api
{
    /// <summary>
    /// This class extends from APIGatewayHttpApiV2ProxyFunction which contains the method FunctionHandlerAsync
    /// which is the actual Lambda function entry point. The Lambda handler field should be set to
    /// Overloop.HealthScheduleApp.Api::Overloop.HealthScheduleApp.Api.LambdaEntryPoint::FunctionHandlerAsync
    /// </summary>
    public class LambdaEntryPoint : APIGatewayHttpApiV2ProxyFunction
    {
        // The Init methods are removed.
        // AddAWSLambdaHosting in Program.cs should handle the application startup.
    }
}