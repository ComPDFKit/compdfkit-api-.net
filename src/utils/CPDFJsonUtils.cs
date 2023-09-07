using System;
using Newtonsoft.Json;

namespace ComPDFKit.utils
{
    public class CPDFJsonUtils
    {
        private const string DEFAULT_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public static string GetJsonString(object bean)
        {
            return GetJsonString(bean, DEFAULT_FORMAT);
        }

        public static string GetJsonString(object bean, string dateFormat)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                DateFormatString = dateFormat,
                NullValueHandling = NullValueHandling.Ignore, // Ignore null values during serialization
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore, // Ignore circular references
                Formatting = Formatting.None // Format output as compact JSON
            };

            try
            {
                return JsonConvert.SerializeObject(bean, settings);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
