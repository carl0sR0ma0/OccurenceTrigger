namespace OccurenceTrigger.Models
{
    public class Occurrence
    {
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Responsable { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
    }
}
