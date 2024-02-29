namespace OccurenceTrigger.Models.Observers
{
    public interface IObserverTrigger
    {
        bool VerifyCondition(IndicatorHistoric indicator);
        void Shoot(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration);
    }
}
