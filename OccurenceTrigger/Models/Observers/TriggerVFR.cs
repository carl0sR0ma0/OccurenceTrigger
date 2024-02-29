namespace OccurenceTrigger.Models.Observers
{
    public class TriggerVFR(double referencePercentage, double lastValue, TriggerModule triggerModule) : IObserverTrigger
    {
        public void Shoot(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration)
        {
            lastValue = indicator.Value;
            triggerModule.OpenOccurrence(indicator, triggerConfiguration, $"Valor fora do range. Valor atual: {indicator.Value}", lastValue);
        }

        public bool VerifyCondition(IndicatorHistoric indicator)
        {
            bool haveChange = lastValue != indicator.Value;

            double upperLimit = indicator.Value * (1 + referencePercentage / 100);
            double lowerLimit = indicator.Value * (1 - referencePercentage / 100);

            return haveChange && (indicator.Value < lowerLimit || indicator.Value > upperLimit);
        }
    }
}
