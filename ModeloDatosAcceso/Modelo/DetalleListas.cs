// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var empty = Empty.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Empty
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }

        [JsonProperty("numTracks")]
        public long NumTracks { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("tracks")]
        public Track[] Tracks { get; set; }

        [JsonProperty("followers")]
        public long Followers { get; set; }

        [JsonProperty("isFreePlaylist")]
        public bool IsFreePlaylist { get; set; }

        [JsonProperty("isUserPlaylist")]
        public bool IsUserPlaylist { get; set; }

        [JsonProperty("isOwnPlaylist")]
        public bool IsOwnPlaylist { get; set; }

        [JsonProperty("isIdentifiedSongsPlaylist")]
        public bool IsIdentifiedSongsPlaylist { get; set; }

        [JsonProperty("userId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long UserId { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("trackNumber")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long TrackNumber { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("internalId")]
        public string InternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("durationInSeconds")]
        public long DurationInSeconds { get; set; }

        [JsonProperty("albumId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long AlbumId { get; set; }

        [JsonProperty("albumName")]
        public string AlbumName { get; set; }

        [JsonProperty("artist")]
        public string[] Artist { get; set; }

        [JsonProperty("artistId")]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] ArtistId { get; set; }

        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("songSourceType")]
        public long SongSourceType { get; set; }

        [JsonProperty("listSourceType")]
        public string ListSourceType { get; set; }

        [JsonProperty("playlistName")]
        public PlaylistName PlaylistName { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public enum PlaylistName { LoEscuchado };

    public partial class Empty
    {
        public static Empty FromJson(string json) => JsonConvert.DeserializeObject<Empty>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Empty self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                PlaylistNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
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

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }

    internal class PlaylistNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PlaylistName) || t == typeof(PlaylistName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            // if (value == "Lo + Escuchado" || value == "Top Latino" || value == "Top USA / UK")
            // {
            return PlaylistName.LoEscuchado;
            // }
            // throw new Exception("Cannot unmarshal type PlaylistName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PlaylistName)untypedValue;
            if (value == PlaylistName.LoEscuchado)
            {
                serializer.Serialize(writer, "Lo + Escuchado");
                return;
            }
            throw new Exception("Cannot marshal type PlaylistName");
        }

        public static readonly PlaylistNameConverter Singleton = new PlaylistNameConverter();
    }
}
