using System.Linq.Expressions;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            string opcio = "";
            while (opcio != "Q" || opcio != "q")
            {
                Console.Clear();
                opcio = Menu();
            }

        }
        static string Menu()
        {
            
            string opcio = "";
=======
            char opcio = '0';
            while (opcio != 'q' && opcio != 'Q')
            {
                do
                {
                    Console.Clear();
                    Console.Write(Menu());
                    Console.WriteLine(opcio);
                    opcio = Console.ReadKey().KeyChar;
                }
                while (!(opcio > '0' && opcio < '7' || opcio == 'q' || opcio == 'Q'));
                Console.Clear();
                MostrarOpcio(opcio);
                
            }

        }

        static void MostrarOpcio(char opcio)
        {

        }
        static string Menu()
        {
>>>>>>> 4cf5c3f7b0cddca9e1f13980fdf6d44331806b92
            Console.Clear();
            string menu =

               $" \n \n " +
               $"\t\t\t\t\t ╔════════════════════════════════╗ \n" +
               $"\t\t\t\t\t ║      GESTIO D'UNA AGENDA       ║ \n" +
               $"\t\t\t\t\t ╠════════════════════════════════╣ \n" +
               $"\t\t\t\t\t ║  1 - Donar d’alta usuari       ║ \n" +
               $"\t\t\t\t\t ║  2 - Recuperar usuari          ║ \n" +
               $"\t\t\t\t\t ║  3 - Modificar usuari          ║ \n" +
               $"\t\t\t\t\t ║  4 - Eliminar usuari           ║ \n" +
               $"\t\t\t\t\t ║  5 - Mostrar agenda            ║ \n" +
               $"\t\t\t\t\t ║  6 - Ordenar agenda            ║ \n" +
               $"\t\t\t\t\t ║  Q - exit                      ║ \n" +
               $"\t\t\t\t\t ╚════════════════════════════════╝" +
               $"\n\n" + "Prem el botó per seleccionar la opció desitjada";

<<<<<<< HEAD
            Console.WriteLine(menu);
            Console.ReadLine();
            switch (opcio)
            {
                case "1":

                    break;
                case "2":

                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":

                    break;
            }


            return opcio;
=======
            return menu;

        }

        static void DonarAlta()
        {

>>>>>>> 4cf5c3f7b0cddca9e1f13980fdf6d44331806b92
        }
    }
}
