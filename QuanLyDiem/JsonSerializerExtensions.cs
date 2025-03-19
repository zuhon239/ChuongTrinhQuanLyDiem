using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QuanLyDiem
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
        }
    }

    // Lớp hỗ trợ giải quyết vấn đề tham chiếu vòng tròn
    public class ReferenceHandler
    {
        public JsonSerializerOptions Options { get; }

        public ReferenceHandler()
        {
            Options = new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };
            Options.Converters.Add(new DateTimeConverter());
        }
    }

    // Lớp mở rộng để hỗ trợ serialization/deserialization JSON
    public static class JsonSerializerExtensions
    {
        private static readonly ReferenceHandler ReferenceHandler = new ReferenceHandler();
        private static JsonSerializerOptions DefaultOptions => ReferenceHandler.Options;

        public static string SerializeToJson<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj, DefaultOptions);
        }

        public static T DeserializeFromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, DefaultOptions);
        }

        public static bool SaveToJsonFile<T>(this T obj, string filePath)
        {
            try
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = obj.SerializeToJson();
                File.WriteAllText(filePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T LoadFromJsonFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
                return new T();

            try
            {
                string json = File.ReadAllText(filePath);
                return json.DeserializeFromJson<T>();
            }
            catch
            {
                return new T();
            }
        }
    }
}
