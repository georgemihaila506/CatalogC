using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    class Student
    {
        private int id;
        private String nume;
        private int grupa;
        private String email;
        private String cadruIndrumator;
        public int Id { get => id; set => id = value; }
        public string Nume { get => nume; set => nume = value; }
        public int Grupa { get => grupa; set => grupa = value; }
        public string Email { get => email; set => email = value; }
        public string CadruIndrumator { get => cadruIndrumator; set => cadruIndrumator = value; }

        public Student(int id, String nume, int grupa, String email, String cadruIndrumator)
        {
            this.id = id;
            this.nume = nume;
            this.grupa = grupa;
            this.email = email;
            this.cadruIndrumator = cadruIndrumator;
        }
        public override string ToString()
        {
            return "Studentul "+ Id + " " + Nume + " " + Grupa + " " + Email + " " + CadruIndrumator;
        }
        public string FullInfo
        {
            get {
                return $"{ id } { nume } { grupa } ({ email }) { CadruIndrumator }";
       
            }
        }

        
    }
}
