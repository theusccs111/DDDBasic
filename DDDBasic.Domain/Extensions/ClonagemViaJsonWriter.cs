using Newtonsoft.Json;
using System.IO;

namespace DDDBasic.Domain.Extensions
{
    public class ClonagemViaJsonWriter : JsonTextWriter
    {
        public ClonagemViaJsonWriter(TextWriter textWriter) : base(textWriter) { }

        public int Depth { get; private set; }

        public override void WriteStartObject()
        {
            Depth++;
            base.WriteStartObject();
        }

        public override void WriteEndObject()
        {
            Depth--;
            base.WriteEndObject();
        }
    }
}