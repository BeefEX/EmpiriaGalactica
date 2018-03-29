using System;
using Newtonsoft.Json;

namespace EmpiriaGalactica {
    public class JsonToInternalNameConvertor : JsonConverter {
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue(((IInternalName) value).InternalName);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            // Creates a new instance of class from a name which is saved in the JSON
            // ReSharper disable once ConvertIfStatementToReturnStatement -- would be too long
            if (reader.TokenType != JsonToken.String)
                return null;

            // ReSharper disable once ConvertIfStatementToReturnStatement -- would be too long
            if (!EmpiriaGalactica.PrototypeManager.Contains((string) reader.Value))
                return null;
            
            return EmpiriaGalactica.PrototypeManager[(string) reader.Value];
        }

        public override bool CanConvert(Type objectType) {
            return objectType.IsSubclassOf(typeof(IInternalName));
        }
    }
}