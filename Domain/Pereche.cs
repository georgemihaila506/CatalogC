using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Pereche
    {
        private int idStudent;
        private int idTema;
        public Pereche(int idStudent, int idTema)
        {
            this.IdStudent = idStudent;
            this.idTema = idTema;
        }

        public int IdTema { get => idTema; set => idTema = value; }
        public int IdStudent { get => idStudent; set => idStudent = value; }
    }
}
