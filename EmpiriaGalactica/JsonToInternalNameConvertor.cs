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
            // ReSharper disable once InvertIf
            if (!EmpiriaGalactica.Buildings.Contains((string) reader.Value))
                if (!EmpiriaGalactica.Resources.Contains((string) reader.Value))
                    return null;
                else
                    return EmpiriaGalactica.Resources[(string) reader.Value];
            
            return EmpiriaGalactica.Buildings[(string) reader.Value];
        }

        public override bool CanConvert(Type objectType) {
            return objectType.IsSubclassOf(typeof(IInternalName));
        }
    }
}