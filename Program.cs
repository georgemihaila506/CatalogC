using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using Domain;
using Repository;
using Validatoare;
using Service;
using UIComand;
namespace LaboratorCS
{
    class Program
    {
        //"Server=.;Database=PentruLaborator;Trusted_Connection=True;" providerName="System.Data.SqlClient"
        static void Main(string[] args)
        {          
            ValidatorStudent val = new ValidatorStudent();                               
            RepositoryStudenti repo = new RepositoryStudenti(val);
            RepositoryTeme repoT = new RepositoryTeme(new ValidatorTema());
            RepositoryNote repoN = new RepositoryNote(new ValidatorNota());
            StudentServices ctrlS = new StudentServices(repo);
            TemeServices ctrlT = new TemeServices(repoT);
            NoteServices ctrlN = new NoteServices(repoN, repo, repoT);
            Consola cons = new Consola(ctrlS, ctrlT, ctrlN);
            cons.runMenu();
            
            




        }
    }
}
