using System;
using Newtonsoft.Json;

namespace EmpiriaGalactica {
    public class JsonToClassNameConverter : JsonConverter {
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            // Saves the name of the class to the JSON
            writer.WriteValue(value.GetType().FullName);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // Creates a new instance of class from a name which is saved in the JSON
            // ReSharper disable once ConvertIfStatementToReturnStatement -- would be too long
            if (reader.TokenType != JsonToken.String)
                return null;
            
            return Activator.CreateInstance(GetType().Assembly.GetType((string) reader.Value));
        }

        public override bool CanConvert(Type objectType) {
            // This can convert any type
            return true;
        }
    }
}