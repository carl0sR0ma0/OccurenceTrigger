using OccurenceTrigger.Data;

namespace OccurenceTrigger.Models
{
    public class MonitoringIndicator(TriggerModule triggerModule, OccurrenceTriggerContext context)
    {
        public void StartMonitoring()
        {
            var indicators = context.IndicatorHistorics
                            .Where(indicator => context.TriggerConfigurations.Any(trigger => trigger.IndicatorId == indicator.IndicatorId))
                            .GroupBy(indicator => indicator.IndicatorId)
                            .Select(group => group.OrderByDescending(ind => ind.Date).First())
                            .ToList();

            foreach (var indicator in indicators)
            {
                triggerModule.NotifyObserver(indicator);
            }
        }
    }
}
