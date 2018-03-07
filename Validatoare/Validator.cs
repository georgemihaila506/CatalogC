using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validatoare
{
    public interface Validator<E>
    {
        void Validare(E obj);
    }
}
