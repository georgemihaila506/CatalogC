using Dapper;
using Domain;
using LaboratorCS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validatoare;

namespace Repository
{
    class RepositoryTeme : AbstractRepository<Tema, int>
    {
        public RepositoryTeme(Validator<Tema> validator) : base(validator)
        {
        }

        public override Tema delete(int id)
        {
            Tema aux = findOne(id);
            if (aux == null)
                return null;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"delete dbo.Teme where numarTema='{id}'").ToList();
                return aux;
            }
        }

        public override Tema findOne(int id)
        {         
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"select * from dbo.Teme where numarTema='{id}'").ToList();
                if (output.Count() == 0)
                    return null;
                return output.First();
            }
        }

        public override List<Tema> get_all()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"select * from dbo.Teme").ToList();
                return output;
            }
        }

        public override Tema save(Tema element)
        {
            base.validator.Validare(element);
            if (findOne(element.NumarTema) != null)
                return element;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"insert into  dbo.Teme values('{element.NumarTema}','{element.Descriere}','{element.Deadline}')").ToList();
                return null;
            }
        }

        public override void update(Tema element)
        {
            base.validator.Validare(element);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"update dbo.Teme set numarTema='{element.NumarTema}',descriere='{element.Descriere}',deadline='{element.Deadline}' where numarTema='{element.NumarTema}'");
            }
        }
    }
}
