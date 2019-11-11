using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DDDBasic.Domain.Enums
{
    public enum Field
    {
        [Description("Nome")]
        Name = 0,
        [Description("Valor")]
        Value = 1
    }
}
