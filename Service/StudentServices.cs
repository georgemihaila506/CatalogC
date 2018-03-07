using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
namespace Service
{
    class StudentServices : Services<Student, int>
    {
        private RepositoryStudenti repo;
        public StudentServices(RepositoryStudenti repo)
        {
            this.repo = repo;
        }
        public Student add(Student element)
        {
            return repo.save(element);
        }

        public Student delete(int id)
        {
            return repo.delete(id);
        }

        public Student findOne(int id)
        {
            return repo.findOne(id);
        }

        public List<Student> get_all()
        {
            return repo.get_all();
        }

        public void update(Student element)
        {
            repo.update(element);
        }
    }
}
