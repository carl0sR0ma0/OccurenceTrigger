using Newtonsoft.Json;

namespace OccurenceTrigger.Models.Configuration
{
    public class EnumToStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumValue = value.ToString();
            writer.WriteValue(enumValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Implemente a lógica de leitura se necessário
            throw new NotImplementedException();
        }
    }

}
