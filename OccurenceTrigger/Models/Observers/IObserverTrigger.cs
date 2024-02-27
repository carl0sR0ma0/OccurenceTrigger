namespace OccurenceTrigger.Models.Observers
{
    public interface IObserverTrigger
    {
        bool VerifyCondition(IndicatorHistoric indicator);
        void Analyze(IndicatorHistoric indicator, TriggerConfiguration triggerConfiguration);
    }
}
