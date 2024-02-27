using OccurenceTrigger.Data;

namespace OccurenceTrigger.Models
{
    public class MonitoringIndicator(TriggerModule triggerModule, OccurrenceTriggerContext context)
    {
        public void StartMonitoring()
        {
            var indicators = context.IndicatorHistorics.ToList();

            foreach (var indicator in indicators)
            {
                triggerModule.NotifyObserver(indicator);
            }
        }
    }
}
