using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Validatoare
{
    class ValidatorTema : Validator<Tema>
    {
        public void Validare(Tema obj)
        {
            String err = " ";
            if (obj.Deadline < 1 && obj.Deadline > 14)
                err = err + "Deadline incorect! ";
            if (obj.Descriere.Equals(""))
                err = err + "Descriere vida! ";
            if(!err.Equals(" "))
                throw new ArgumentException(err);
        }
    }
}
