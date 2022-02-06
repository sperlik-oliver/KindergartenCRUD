using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Client.Utility
{
    public static class CustomJsonConvert
    {
        private static readonly DefaultContractResolver defaultContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };

        public static string SerializeObject(object o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings
            {
                // ContractResolver = defaultContractResolver,
                Formatting = Formatting.Indented
            });
        }
    }
}