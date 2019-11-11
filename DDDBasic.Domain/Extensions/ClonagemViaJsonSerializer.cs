using System;
using System.IO;
using System.Linq;

namespace DDDBasic.Domain.Extensions
{
    public class ClonagemViaJsonSerializer
    {
        public static string SerializeObject(object objetoParaClonar, int profundidade,string[] propriedadesParaIgnorar)
        {

            using (var stringWriter = new StringWriter())
            {
                using (var jsonWriter = new ClonagemViaJsonWriter(stringWriter))
                {
                    Func<bool> includeFunction = () => jsonWriter.Depth <= profundidade;
                    Func<string, bool> funcaoDeValidacaoDePropriedade = (propriedade) => !propriedadesParaIgnorar.Contains(propriedade);
                    var resolver = new ClonagemViaJsonContractResolver(includeFunction, funcaoDeValidacaoDePropriedade);
                    var serializer = new Newtonsoft.Json.JsonSerializer () { ContractResolver = resolver, ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore};
                    serializer.Serialize(jsonWriter, objetoParaClonar);
                }
                return stringWriter.ToString();
            }
        }

    }
}
