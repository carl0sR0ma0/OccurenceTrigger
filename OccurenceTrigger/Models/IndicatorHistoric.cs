using OccurenceTrigger.Models.Enum;

namespace OccurenceTrigger.Models
{
    public class IndicatorHistoric
    {
        public int IndicatorId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public int Reability { get; set; }
        public TypeWorkshift Workshift { get; set; }
        public bool AdherenceShift { get; set; }
    }
}
