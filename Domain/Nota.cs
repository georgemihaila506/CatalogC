using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Nota
    {
        private Pereche pereche;
        private int idStudent;
        private int idTema;
        private int notaS;        
        public int NotaS { get => notaS; set => notaS = value; }
        public int IdTema { get => idTema; set => idTema = value; }
        public int IdStudent { get => idStudent; set => idStudent = value; }
        internal Pereche Pereche { get => pereche; set => pereche = value; }

        public override string ToString()
        {
            return "Nota " + idStudent + " " + idTema + " " + notaS;
        }
        public Nota(Pereche pereche, int nota)
        {
            this.idStudent = pereche.IdStudent;
            this.idTema = pereche.IdTema;
            this.pereche = pereche;
            this.notaS = nota;
        }
        public Nota(int idStudent, int idTema, int notaS)
        {
            this.idStudent = idStudent;
            this.idTema = idTema;
            this.notaS = notaS;
            this.pereche = new Pereche(idStudent, idTema);
        }
        public string FullInfo
        {
            get
            {
                return $"{ idStudent } { idTema } { notaS }";

            }
        }
    }
}
