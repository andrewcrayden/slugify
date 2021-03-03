using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CamelCase
{
    public class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            if (value == null) { return null; }
            return Regex.Replace(value.ToString(),
                   "([a-z])(\\s+)?((?(2)\\S|[A-Z]))",
                   "$1-$3",
                   RegexOptions.CultureInvariant,
                   TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
        }
    }
}
