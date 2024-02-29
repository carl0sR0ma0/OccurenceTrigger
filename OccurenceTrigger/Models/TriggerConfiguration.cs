using OccurenceTrigger.Models.Enum;

namespace OccurenceTrigger.Models
{
    public class TriggerConfiguration
    {
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public bool Status { get; set; }
        public TypeTrigger TypeTrigger { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double LastValue { get; set; }
        public double ReferencePercentage { get; set; }
        public bool AdherenceShift { get; set; }   
    }
}
