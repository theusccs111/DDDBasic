using DDDBasic.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDDBasic.Application.Helpers
{
    public static class EnumsHelper
    {
        public static string ReturnMessage(Enum enumPrincipal)
        {
            return string.Format(enumPrincipal.GetDescription());
        }

        public static string ReturnMessage(Enum enumPrincipal, params Enum[] enums)
        {
            return string.Format(enumPrincipal.GetDescription(), enums.Select(e => e.GetDescription()).ToArray());
        }

        public static string ReturnMessage(Enum enumPrincipal, string complemento)
        {
            return string.Format(enumPrincipal.GetDescription(), complemento);
        }

        public static string ReturnMessage(Enum enumPrincipal, params string[] strings)
        {
            return string.Format(enumPrincipal.GetDescription(), strings);
        }
    }
}
