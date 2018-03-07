using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Domain;
namespace UIComand
{
    class Consola
    {
        private static MenuCommand main_menu;
        private static NoteServices ctrlN;
        private static TemeServices ctrlT;
        private static StudentServices ctrlS;

        public Consola(StudentServices ctrlS1, TemeServices ctrlT1, NoteServices ctrlN1)
        {
            ctrlN = ctrlN1;
            ctrlS = ctrlS1;
            ctrlT = ctrlT1;
        }
        public class ExitCommand : Command
        {
            public void execute()
            {
                Environment.Exit(0);
            }
        }
        public class AddStudent : Command
        {
            public void execute()
            {
                int id = 0;
                String nume = "";
                int grupa = 0;
                String email = "";
                String tutore = "";
                Console.WriteLine("Introduceti id:");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti nume:");
                nume = Console.ReadLine();
                Console.WriteLine("Introduceti grupa:");
                grupa = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti email:");
                email = Console.ReadLine();
                Console.WriteLine("Introduceti tutorele:");
                tutore = Console.ReadLine();
                try
                {
                    ctrlS.add(new Student(id, nume, grupa, email, tutore));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class UpdateStudent : Command
        {
            public void execute()
            {
                int id = 0;
                String nume = "";
                int grupa = 0;
                String email = "";
                String tutore = "";
                Console.WriteLine("Introduceti id:");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti nume:");
                nume = Console.ReadLine();
                Console.WriteLine("Introduceti grupa:");
                grupa = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti email:");
                email = Console.ReadLine();
                Console.WriteLine("Introduceti tutorele:");
                tutore = Console.ReadLine();
                try
                {
                    ctrlS.update(new Student(id, nume, grupa, email, tutore));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class DeleteStudent : Command
        {
            public void execute()
            {
                int id = 0;               
                Console.WriteLine("Introduceti id:");
                id = int.Parse(Console.ReadLine());               
                try
                {
                    ctrlS.delete(id);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class GetAllStudent : Command
        {
            public void execute()
            {

                ctrlS.get_all().ForEach(x => Console.WriteLine(x));
            }
        }
        public class AddTema : Command
        {
            public void execute()
            {
                int id = 0;
                int deadline;
                String descriere;
                Console.WriteLine("Introduceti id:");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti descriere:");
                descriere = Console.ReadLine();
                Console.WriteLine("Introduceti deadline:");
                deadline = int.Parse(Console.ReadLine());
                try
                {
                    ctrlT.add(new Tema(id, descriere, deadline));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class DeleteTema : Command
        {
            public void execute()
            {
                int id = 0;               
                Console.WriteLine("Introduceti id:");
                id = int.Parse(Console.ReadLine());              
                try
                {
                    ctrlT.delete(id);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class AddNota : Command
        {
            public void execute()
            {
                int idT, idS, nota,sapt;
                Console.WriteLine("Introduceti id student:");
                idS = int.Parse(Console.ReadLine());               
                Console.WriteLine("Introduceti id tema:");
                idT = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti nota:");
                nota = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti saptamana:");
                sapt = int.Parse(Console.ReadLine());
                try
                {
                    if (ctrlS.findOne(idS) == null || ctrlT.findOne(idT) == null)
                        Console.WriteLine("Student sau tema nu exista");
                    else
                        ctrlN.addNota(new Nota(new Pereche(idS,idT),nota),sapt);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class UpdateNota : Command
        {
            public void execute()
            {
                int idT, idS, nota, sapt;
                Console.WriteLine("Introduceti id student:");
                idS = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti id tema:");
                idT = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti nota:");
                nota = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduceti saptamana:");
                sapt = int.Parse(Console.ReadLine());
                try
                {
                    if (ctrlS.findOne(idS) == null || ctrlT.findOne(idT) == null)
                        Console.WriteLine("Student sau tema nu exista");
                    else
                        ctrlN.updateNota(new Nota(new Pereche(idS, idT), nota), sapt);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e);

                }
            }
        }
        public class GetAllTema : Command
        {
            public void execute()
            {

                ctrlT.get_all().ForEach(x => Console.WriteLine(x));
            }
        }
        public class GetAllNote : Command
        {
            public void execute()
            {

                ctrlN.get_all().ForEach(x => Console.WriteLine(x));
            }
        }

        public void createMenu()
        {
            main_menu = new MenuCommand("_____Meniu Principal_____");

            MenuCommand studentMenu = new MenuCommand("_____Meniu Student_____");
            studentMenu.addCommand("1.Revenire meniu principal", main_menu);
            studentMenu.addCommand("2.Adaugare Student", new AddStudent());
            studentMenu.addCommand("3.Actualizare Student", new UpdateStudent());
            studentMenu.addCommand("4.Sterge un student", new DeleteStudent());
            studentMenu.addCommand("5.Afisare tuturor studentinlor", new GetAllStudent());

            MenuCommand temeMenu = new MenuCommand("_____Meniu Teme_____");
            temeMenu.addCommand("1.Revenire meniu principal", main_menu);
            temeMenu.addCommand("2.Adaugare Tema", new AddTema());
            temeMenu.addCommand("3.Modificare deadline", new DeleteTema());
            temeMenu.addCommand("4.Afisarea tuturor temelor", new GetAllTema());

            MenuCommand noteMenu = new MenuCommand("_____Meniu Note_____");
            noteMenu.addCommand("1.Revenire meniu principal", main_menu);
            noteMenu.addCommand("2.Adaugare nota", new AddNota());
            noteMenu.addCommand("3.Modificare nota", new UpdateNota());
            noteMenu.addCommand("4.Afisarea tuturor notelor", new GetAllNote());


            main_menu.addCommand("1.Exit", new ExitCommand());
            main_menu.addCommand("2.Meniu Studenti", studentMenu);
            main_menu.addCommand("3.Meniu Teme", temeMenu);
            main_menu.addCommand("4.Meniu Note", noteMenu);
        }
        public void runMenu()
        {
            createMenu();
            MenuCommand meniuCurent = main_menu;
            while (true)
            {
                Console.WriteLine(meniuCurent.getMenuName());
                meniuCurent.execute();
                Console.WriteLine("_____");
                Console.WriteLine("Introduceti optiunea: ");
                int optiune = int.Parse(Console.ReadLine());
                if (optiune >= 0 && optiune <= meniuCurent.getCommand().Count)
                {
                    Command comandaSelectata = meniuCurent.getCommand().ElementAt(optiune-1);
                    if (comandaSelectata is MenuCommand)
                    {
                        meniuCurent = (MenuCommand)comandaSelectata;
                    }
                    else
                        comandaSelectata.execute();
                }
            }
        }


    }
}
