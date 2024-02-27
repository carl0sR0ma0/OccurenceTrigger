using OccurenceTrigger.Models.Enum;

namespace OccurenceTrigger.Models
{
    public class Indicator
    {
        public int Id { get; set; }
        public int ProductionUnitId { get; set; }
        public string System { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public TypeIndicator Type { get; set; }
        public string Area { get; set; } = string.Empty;
        public string CalcType { get; set; } = string.Empty;
    }
}
