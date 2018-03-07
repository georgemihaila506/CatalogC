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
    class RepositoryNote : AbstractRepository<Nota, Pereche>
    {
        public RepositoryNote(Validator<Nota> validator) : base(validator)
        {

        }

        public override Nota delete(Pereche id)
        {
            Nota aux = findOne(id);
            if (aux == null)
                return null;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Nota>($"delete from dbo.Note where idStudent='{id.IdStudent}' and idTema='{id.IdTema}'").ToList();
                return aux;
            }
        }

        public override Nota findOne(Pereche id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Nota>($"select * from dbo.Note where idStudent='{id.IdStudent}' and idTema='{id.IdTema}'").ToList();
                if (output.Count() == 0)
                    return null;
                return output.First();
            }
        }

        public override List<Nota> get_all()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Nota>($"select * from dbo.Note").ToList();
                return output;
            }
        }

        public override Nota save(Nota element)
        {
            base.validator.Validare(element);
            if (findOne(element.Pereche) != null)
                return element;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Nota>($"insert into dbo.Note values('{element.IdStudent}','{element.IdTema}','{element.NotaS}')");
                //var output = connection.Query<Nota>($"insert into dbo.Note values('1,1,1')");
                return null;
            }
        }

        public override void update(Nota element)
        {
            base.validator.Validare(element);
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Nota>($"update dbo.Note set idStudent='{element.IdStudent}',idTema='{element.IdTema}',notaS='{element.NotaS}'");
            }
        }
    }
}
