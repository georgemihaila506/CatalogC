using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorCS
{
    class clasa
    {
        public clasa()
        { }
        public List<Student> cautaStudenti()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Student>($"select * from dbo.Studenti").ToList();
                return output;
            }
        }
        public List<Tema> cautaTeme()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("LaboratorDB")))
            {
                var output = connection.Query<Tema>($"select * from dbo.Teme").ToList();
                return output;
            }
        }
    }
}
