namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
        static void Menu()
        {
            
            char opcio = ' ';
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

            Console.WriteLine(menu);
        }
    }
}
