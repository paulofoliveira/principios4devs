using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Principios4DevsClassificacao
{
    internal class ApoliceSerializador
    {
        public Apolice RecuperarPorJsonString(string apoliceJson)
        {
            return JsonConvert.DeserializeObject<Apolice>(apoliceJson, new StringEnumConverter());
        }
    }
}
