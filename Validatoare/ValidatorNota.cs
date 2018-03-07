using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Validatoare
{
    class ValidatorNota : Validator<Nota>
    {
        public void Validare(Nota obj)
        {
            String err = " ";
            if (obj.NotaS < 0 || obj.NotaS > 10)
                err = err + "Nota incorecta! ";
            if(!err.Equals(" "))
                throw new ArgumentException(err);
        }
    }
}
