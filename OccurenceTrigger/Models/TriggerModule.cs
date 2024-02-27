using OccurenceTrigger.Data;
using OccurenceTrigger.Models.Observers;

namespace OccurenceTrigger.Models
{
    public class TriggerModule(OccurrenceTriggerContext context)
    {
        public void NotifyObserver(IndicatorHistoric indicator)
        {
            var triggerConfigurations = context.TriggerConfigurations
            .Where(c => c.IndicatorId == indicator.IndicatorId)
            .ToList();

            foreach (var triggerConfiguration in triggerConfigurations)
            {
                var observer = CreateObserver(triggerConfiguration);

                if ((bool)(observer?.VerifyCondition(indicator)))
                    observer?.Analyze(indicator, triggerConfiguration);
            }
        }

        private IObserverTrigger? CreateObserver(TriggerConfiguration triggerConfiguration)
        {
            return triggerConfiguration.TypeTrigger switch
            {
                Enum.TypeTrigger.VLV => new TriggerVLV(triggerConfiguration.MinValue, triggerConfiguration.MaxValue, triggerConfiguration.LastValue, this),
                Enum.TypeTrigger.VFR => new TriggerVFR(triggerConfiguration.ReferencePercentage, triggerConfiguration.LastValue, this),
                Enum.TypeTrigger.ALT => new TriggerALT(TimeSpan.FromHours(1), TimeSpan.FromHours(1), null, this),
                _ => null,
            };
        }

        public void OpenOccurrence(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration, string message, double? lastValue = null)
        {
            if (lastValue is not null)
            {
                triggerConfiguration.LastValue = (double)lastValue;
                context.TriggerConfigurations.Update(triggerConfiguration);
                context.SaveChanges();
            }

            var occurrence = new Occurrence
            {
                IndicatorId = indicator.IndicatorId,
                CreationDate = DateTime.Now,
                Responsable = "Pentagro",  // Substitua pelo responsável real
                Reason = $"Gatilho {triggerConfiguration.TypeTrigger}: {message}",
                Deadline = DateTime.Now.AddDays(3)
            };

            context.Occurrences.Add(occurrence);
            context.SaveChanges();
        }
    }
}