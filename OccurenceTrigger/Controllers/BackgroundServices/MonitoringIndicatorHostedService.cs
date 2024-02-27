using OccurenceTrigger.Data;
using OccurenceTrigger.Models;

namespace OccurenceTrigger.Controllers.BackgroundServices
{
    // Implementação do serviço IHostedService para iniciar o monitoramento
    public class MonitoringIndicatorHostedService(IServiceProvider serviceProvider, ILogger<MonitoringIndicatorHostedService> logger) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly ILogger<MonitoringIndicatorHostedService> _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    try
                    {
                        var moduloGatilhos = scope.ServiceProvider.GetRequiredService<TriggerModule>();
                        var dbContext = scope.ServiceProvider.GetRequiredService<OccurrenceTriggerContext>();
                        new MonitoringIndicator(moduloGatilhos, dbContext).StartMonitoring();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Erro ao iniciar o monitoramento de indicadores");
                    }
                }
                await Task.Delay(15000, stoppingToken);
            }
        }
    }
}
