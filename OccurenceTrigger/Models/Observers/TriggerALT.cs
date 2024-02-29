namespace OccurenceTrigger.Models.Observers
{
    public class TriggerALT(TimeSpan timeOffMilling, TimeSpan timeBeforeEndShift, DateTime? lastRegisterMilling, TriggerModule triggerModule) : IObserverTrigger
    {
        private readonly TriggerModule triggerModule = triggerModule;

        public void Shoot(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration)
        {
            triggerModule.OpenOccurrence(indicator, triggerConfiguration, $"Indicador não aderente no turno. Valor atual: {indicator.Value}");
        }

        public bool VerifyCondition(IndicatorHistoric indicator)
        {
            if (indicator.AdherenceShift)
                lastRegisterMilling = DateTime.Now;
            else if (lastRegisterMilling.HasValue && DateTime.Now - lastRegisterMilling.Value > timeOffMilling)
            {
                DateTime endShift = DateTime.Now.Date.AddHours(24).Add(-timeBeforeEndShift);
                if (DateTime.Now >= endShift)
                    return true;
            }

            return false;
        }
    }
}
