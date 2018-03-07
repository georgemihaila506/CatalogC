using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.Data;
using Dapper;
using LaboratorCS;
using Validatoare;
namespace Repository
{
    class RepositoryStudenti : AbstractRepository<Student, int>
    {
        public RepositoryStudenti(Validator<Student> validator) : base(validator)
        {
        }

        public override Student delete(int id)
        {
            Student aux = findOne(id);
            if (aux == null)
                return null;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"delete Studenti where id='{id}'");
                return aux;
            }
        }

        public override Student findOne(int id)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(LaboratorCS.Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"select * from dbo.Studenti where '{id}'=id").ToList();
                if (output.Count() == 0)
                    return null;
                else
                    return output.First();
            }
        }

        public override List<Student> get_all()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"select * from dbo.Studenti").ToList();
                return output;
            }
        }

        public override Student save(Student element)
        {
            base.validator.Validare(element);
            if (findOne(element.Id)!=null)
                return element;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"insert into Studenti values('{element.Id}','{element.Nume}','{element.Grupa}','{element.Email}','{element.CadruIndrumator}')").ToList();
                return null;
            }
        }

        public override void update(Student element)
        {
            base.validator.Validare(element);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"Update Studenti set id='{element.Id}',nume='{element.Nume}',grupa='{element.Grupa}',email='{element.Email}',cadruIndrumator='{element.CadruIndrumator}' where id='{element.Id}'");
            }
        }
    }
}
