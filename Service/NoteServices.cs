using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repository;
namespace Service
{
    class NoteServices : Services<Nota, Pereche>
    {
        private RepositoryNote repo;
        private RepositoryStudenti repoS;
        private RepositoryTeme repoT;
        public NoteServices(RepositoryNote repo,RepositoryStudenti repoS,RepositoryTeme repoT)
        {
            this.repo = repo;
            this.repoS = repoS;
            this.repoT = repoT;
        }
        public Nota add(Nota element)
        {
            return repo.save(element);
        }
        public Nota addNota(Nota element, int saptamanaP)
        {
            Tema tema = repoT.findOne(element.IdTema);
            String observatii = "";
            if ((saptamanaP - tema.Deadline) == 1)
            {
                element.NotaS = element.NotaS - 2;
                observatii = observatii + "Intarziere";
            }
            if ((saptamanaP - tema.Deadline) == 2)
            {
                element.NotaS = element.NotaS - 4;
                observatii = observatii + "Intarziere";
            }
            if ((saptamanaP - tema.Deadline) > 2)
            {
                element.NotaS = 1;
                observatii = observatii + "Intarziere";
            }
            if (element.NotaS == 10)
                observatii = observatii + "OK";
            else
                observatii = observatii + " " + "Greseli";
            Nota aux=add(element);
            String cale = "";
            cale = cale + @"C:\Users\George\Documents\Visual Studio 2017\Projects\LaboratorCS\LaboratorCS\" + element.IdStudent.ToString() + "Student.txt";
            String text = "Adaugare nota " + element.IdTema.ToString() + " " + element.NotaS.ToString() + " " + tema.Deadline.ToString() + " " + saptamanaP.ToString() +" "+observatii+Environment.NewLine;
            //System.IO.File.WriteAllText(cale, text);
            System.IO.File.AppendAllText(cale, text);
            return aux;
        }
        public void updateNota(Nota element, int saptamanaP)
        {
            Tema tema = repoT.findOne(element.IdTema);
            Nota el = repo.findOne(element.Pereche);
            String observatii = "";
            if (el != null)
            {
                if ((saptamanaP - tema.Deadline) == 1)
                {
                    element.NotaS = element.NotaS - 2;
                    observatii = observatii + "Intarziere";
                }
                if ((saptamanaP - tema.Deadline) == 2)
                {
                    element.NotaS = element.NotaS - 4;
                    observatii = observatii + "Intarziere";
                }
                if ((saptamanaP - tema.Deadline) > 2)
                {
                    element.NotaS = 1;
                    observatii = observatii + "Intarziere";
                }
                if (element.NotaS == 10)
                    observatii = observatii + "OK";
                else
                    observatii = observatii + " " + "Greseli";
                if (element.NotaS > el.NotaS)
                { update(element);

                    String cale = "";
                    cale = cale + @"C:\Users\George\Documents\Visual Studio 2017\Projects\LaboratorCS\LaboratorCS\" + el.IdStudent.ToString() + "Student.txt";
                    String text = "Modificare nota " + el.IdTema.ToString() + " " + el.NotaS.ToString() + " " + tema.Deadline.ToString() + " " + saptamanaP.ToString() +" "+observatii+Environment.NewLine;

                    //System.IO.File.WriteAllText(cale, observatii);
                    System.IO.File.AppendAllText(cale, text);
                }
            }
        }
        public Nota delete(Pereche id)
        {
            return repo.delete(id);
        }

        public Nota findOne(Pereche id)
        {
            return repo.findOne(id);
        }

        public List<Nota> get_all()
        {
            return repo.get_all();
        }

        public void update(Nota element)
        {
            repo.update(element);
        }
    }
}
