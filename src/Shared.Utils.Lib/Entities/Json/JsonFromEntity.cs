using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ZanyBaka.Shared.Utils.Lib.Entities.Json
{
    public class JsonFromEntity
    {
        private readonly Lazy<string> _lazyValue;

        public JsonFromEntity(object input) : this(input, Encoding.UTF8)
        {
        }

        public JsonFromEntity(object input, Encoding encoding)
        {
            _lazyValue = new Lazy<string>(() => CreateJsonFromEntity(input, encoding));
        }

        public static implicit operator string(JsonFromEntity obj)
        {
            return obj.GetValue();
        }

        public string GetValue()
        {
            return _lazyValue.Value;
        }

        public override string ToString()
        {
            return GetValue();
        }

        private static string CreateJsonFromEntity(object entity, Encoding encoding)
        {
            var serializer = new DataContractJsonSerializer(entity.GetType());

            using (var stream = new MemoryStream())
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream, encoding))
                {
                    serializer.WriteObject(writer, entity);
                }

                return encoding.GetString(stream.ToArray());
            }
        }
    }
}