using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


// paginas https://app.quicktype.io/#l=cs&r=json2csharp y http://json2csharp.com/

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//    var Listas = Listas.FromJson(jsonString);

namespace ModeloDatosAcceso.ModeloNegocio
{


    public partial class Listas
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("elements")]
        public Element[] Elements { get; set; }
    }

    public partial class Element
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("isFollowing")]
        public bool IsFollowing { get; set; }
    }

    public enum Author { ClaroMúsicaMx };

    public enum TypeEnum { Free };

    public partial class Listas
    {
        public static Listas FromJson(string json) => JsonConvert.DeserializeObject<Listas>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Listas self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                AuthorConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AuthorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Author) || t == typeof(Author?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "Claro música MX")
            {
                return Author.ClaroMúsicaMx;
            }
            throw new Exception("Cannot unmarshal type Author");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Author)untypedValue;
            if (value == Author.ClaroMúsicaMx)
            {
                serializer.Serialize(writer, "Claro música MX");
                return;
            }
            throw new Exception("Cannot marshal type Author");
        }

        public static readonly AuthorConverter Singleton = new AuthorConverter();
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "free")
            {
                return TypeEnum.Free;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Free)
            {
                serializer.Serialize(writer, "free");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}

