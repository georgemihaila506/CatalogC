using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Domain;
namespace Service
{
    class TemeServices : Services<Tema, int>
    {
        private RepositoryTeme repo;
        public TemeServices(RepositoryTeme repo)
        { this.repo = repo; }
        public Tema add(Tema element)
        {
            return repo.save(element);
        }

        public Tema delete(int id)
        {
            return repo.delete(id);
        }

        public Tema findOne(int id)
        {
            return repo.findOne(id);
        }

        public List<Tema> get_all()
        {
            return repo.get_all();
        }

        public void update(Tema element)
        {
            repo.update(element);
        }
        public void updateDeadline(int nrTema, int saptamanaC,int noulDeadline)
        {
            Tema aux = findOne(nrTema);
            if (aux!= null && aux.Deadline<noulDeadline)
            {
                if (aux.Deadline < saptamanaC)
                    repo.update(new Tema(nrTema, aux.Descriere, noulDeadline));
            }
        }
    }
}
