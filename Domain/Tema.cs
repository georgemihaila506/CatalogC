using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Tema
    {
        private int numarTema;
        private String descriere;
        private int deadline;
        public int NumarTema { get => numarTema; set => numarTema = value; }
        public string Descriere { get => descriere; set => descriere = value; }
        public int Deadline { get => deadline; set => deadline = value; }

        public Tema(int numarTema, String descriere, int deadline)
        {
            this.numarTema = numarTema;
            this.descriere = descriere;
            this.deadline = deadline;
        }
        public override string ToString()
        {
            return "Tema " + NumarTema + " " + Descriere + " " + Deadline;
        }
        public string FullInfo
        {
            get
            {
                return $"{ numarTema } { descriere } { deadline }";

            }
        }
    }
}
