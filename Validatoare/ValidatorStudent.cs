using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validatoare
{
    class ValidatorStudent : Validator<Student>
    {
        public void Validare(Student obj)
        {
            String err = " ";
            if (obj.Nume.Equals(""))
                err = err + "Numele e vid! ";
            if (obj.Grupa < 99 || obj.Grupa > 999)
                err = err + "Grupa incorecta! ";
            if (obj.Email.Equals(""))
                err = err + "Email-ul e vid! ";
            if (obj.CadruIndrumator.Equals(""))
                err = err + "Tutorele e vid! ";
            if (!err.Equals(" "))
                throw new ArgumentException(err);
        }
    }
}
