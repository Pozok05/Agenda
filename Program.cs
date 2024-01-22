using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace Agenda
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

       
        static string Menu()
        {
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

            return menu;

        }
        static void MostrarOpcio(char opcio)
        {
            switch (opcio)
            {
                case '1':
                    DonarAlta();
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
            }
        }

        static void DonarAlta()
        {
            string nom, cognom1, cognom2, dni, telefon, correu, aux;
            DateTime dataNaixament;
            Console.WriteLine("Escriu el teu nom:");
            nom = Console.ReadLine();
            nom = NomVerificat(nom);
            Console.Clear();
            Console.WriteLine("Escriu el teu cognom1:");
            cognom1 = Console.ReadLine();
            cognom1 = NomVerificat(cognom1);
            Console.Clear();
            Console.WriteLine("Escriu el teu cognom2:");
            cognom2 = Console.ReadLine();
            cognom2 = NomVerificat(cognom2);
            Console.Clear();
            //DNI



            telefon = VerificaTelefon();
            dataNaixament = VerificaDataNaixament();
            correu = VerificaCorreu();

            do {
                Console.WriteLine("Escriu el teu nom:");
                nom = Console.ReadLine();

            } 
            while (nom != null);
            
        }

        static string NomVerificat(string nom)
        {
            string res = "";
            nom = nom.ToLower();
            nom = nom.Trim();
            for (int i = 0; i < nom.Length; i++)
            {
                if (char.IsLetter(nom[i]))
                {
                    res += nom[i];
                    if(res.Length == 1) res.ToUpper();
                }
            }
            return res;
        }

        static string VerificaTelefon()
        {
            string telefon = "";
            int aux = 0;
            Console.Clear();
            Console.WriteLine("Escriu el teu telefon:");
            telefon = Console.ReadLine();
            int.TryParse(telefon, out aux);
            while(!(aux >= 100000000 && aux <= 999999999))
            {
                Console.Clear();
                Console.WriteLine("El telefon esta mal escrit, ha de tenir 9 digits");
                Console.WriteLine("Prova a escriure el telefon una altra vegada:");
                telefon = Console.ReadLine();
                int.TryParse(telefon, out aux);
            }
            telefon = aux.ToString();
            return telefon;
        }

        static DateTime VerificaDataNaixament()
        {
            string datanaixament;
            DateTime resultat;
            Console.Clear();
            Console.WriteLine("Escriu la teva data de naixament:");
            datanaixament = Console.ReadLine();
            DateTime.TryParse(datanaixament, out resultat);
            while(resultat == DateTime.MinValue || resultat >= DateTime.Today)
            {
                Console.Clear();
                Console.WriteLine("La data esta mal escrita, ha de ser un format DateTime valid");
                Console.WriteLine("Prova a escriure la data una altra vegada");
                datanaixament = Console.ReadLine();
                DateTime.TryParse(datanaixament, out resultat);
            }
            return resultat;
        }
        static string VerificaCorreu()
        {
            string correu;
            Console.Clear();
            Console.WriteLine("Escriu el teu correu electronic:");
            correu = Console.ReadLine();
            while (Regex.IsMatch(correu, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                Console.Clear();
                Console.WriteLine("El correu esta mal escrit");
                Console.WriteLine("Prova a escriure el correu una altra vegada");
                correu = Console.ReadLine();
            }
            return correu;
        }
        

        static void RecuperarUsuari()
        {

        }
        static void ModificarUsuari()
        {

        }
        static void EliminarUsuari()
        {

        }
        static void MostrarAgenda()
        {

        }
        static void OrdenarAgenda()
        {

        }

    }
}
