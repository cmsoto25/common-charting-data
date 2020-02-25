using Newtonsoft.Json;

namespace TC.AmiBroker.Data
{
    public class JsonResponseSerializer<T> : IResponseSerializer<T>
    {
        protected virtual JsonSerializerSettings Settings
        {
            get {
                return new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified,
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss"
                };
            }
        }

        public T Deserialize(string data)
        {
            return JsonConvert.DeserializeObject<T>(data, Settings);
        }

        public string Serialize(T data)
        {
            return JsonConvert.SerializeObject(data, Settings);
        }
    }
}
