using System;
using System.Collections.Generic;
using System.Text;

namespace DDDBasic.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entidade \"{name}\" ({key}) não encontrada.")
        {
        }

        public NotFoundException(string name) : base($"{name}")
        {

        }
    }
}
