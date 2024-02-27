namespace OccurenceTrigger.Models.Observers
{
    public class TriggerVLV(double minValue, double maxValue, double lastValue, TriggerModule triggerModule) : IObserverTrigger
    {
        public void Analyze(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration)
        {
            lastValue = indicator.Value;
            triggerModule.OpenOccurrence(indicator, triggerConfiguration, $"Valor fora do range. Valor atual: {indicator.Value}", lastValue);
        }

        public bool VerifyCondition(IndicatorHistoric indicator)
        {
            bool haveChange = lastValue != indicator.Value;
            return haveChange && (indicator.Value < minValue || indicator.Value > maxValue);
        }
    }
} 
