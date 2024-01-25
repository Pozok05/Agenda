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

        // MENU
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
        // Donar Alta 
        static void DonarAlta()
        {
            string nom, cognom1, cognom2, dni=" ", telefon, dataNaixement, correu, persona;
            int edat;
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
            dni = VerificaDni();
            telefon = VerificaTelefon();
            DateTime dateNaixement;
            dataNaixement = VerificaDataNaixement(out dateNaixement);
            correu = VerificaCorreu();
            persona = $"{nom},{cognom1},{cognom2},{dni},{telefon},{dataNaixement},{correu}";
            EscriuUsuariFitxer(persona);
            Console.Clear();
            Console.WriteLine($"Nom: {nom}\tCognom1: {cognom1}\tCognom2: {cognom2}\nDni: {dni}\tTelefon: {telefon}\nData naixement: {dataNaixement}\tEdat: {CalcularEdat(dateNaixement)} anys\nCorreu: {correu}");
            Thread.Sleep(3000);
        }
        static int CalcularEdat(DateTime dataNaixement)
            {
                DateTime dataActual = DateTime.Now;
                int edat = dataActual.Year - dataNaixement.Year;
                if ((dataNaixement.Month > dataActual.Month) || (dataNaixement.Month == dataActual.Month && dataNaixement.Day > dataActual.Day))
                    edat--;
                return edat;
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
                }
            }
            res = res.Substring(0,1).ToUpper() + res.Substring(1);
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
        static string VerificaDni()
        {
            string dni;
            Console.Clear();
            Console.WriteLine("Escriu el teu dni:");
            dni = Console.ReadLine();
            while (!DniValid(dni))
            {
                Console.Clear();
                Console.WriteLine("El dni esta mal escrit, recorda que es format 123455678A");
                Console.WriteLine("Escriu el teu dni:");
                dni = Console.ReadLine();
            }
            return dni;
        }
        static bool DniValid(string dni)
        {
            
            string dniChars = "TRWAGMYFPDXBNJZSQVHLCKET";
            Regex regexDni = new Regex("^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKET]$");
            bool valid = regexDni.IsMatch(dni);
            if(valid)
            {
                char c = dni[dni.Length - 1];
                if(!(c == dniChars[Convert.ToInt32(dni.Substring(0, dni.Length - 1)) % 23]))
                {
                    valid = false;
                }
            }
            return valid;
        }
        static string VerificaDataNaixement(out DateTime resultat)
        {
            string datanaixement;
            Console.Clear();
            Console.WriteLine("Escriu la teva data de naixement:");
            datanaixement = Console.ReadLine();
            DateTime.TryParse(datanaixement, out resultat);
            while(resultat == DateTime.MinValue || resultat >= DateTime.Today)
            {
                Console.Clear();
                Console.WriteLine("La data esta mal escrita, ha de ser un format DateTime valid");
                Console.WriteLine("Prova a escriure la data una altra vegada");
                datanaixement = Console.ReadLine();
                DateTime.TryParse(datanaixement, out resultat);
            }
            //datanaixament = resultat.Date.ToString("d");
            return resultat.Date.ToString("d");
        }
        static string VerificaCorreu()
        {
            string correu;
            Console.Clear();
            Console.WriteLine("Escriu el teu correu electronic:");
            correu = Console.ReadLine();
            while (!Regex.IsMatch(correu, @"^[a-zA-Z0-9._%-]{3,}@[a-zA-Z]{3,}\.(com||es)$"))
            {
                Console.Clear();
                Console.WriteLine("El correu esta mal escrit");
                Console.WriteLine("Prova a escriure el correu una altra vegada");
                correu = Console.ReadLine();
            }
            return correu.ToLower();
        }
        static void EscriuUsuariFitxer(string persona)
        {
            StreamReader sr = new StreamReader(@".\agenda.txt");
            StreamWriter sw = new StreamWriter(@".\aux.txt");
            sw.Write(sr.ReadToEnd());
            sr.Close();
            sw.Write(persona);
            sw.Close();
            sr = new StreamReader(@".\aux.txt");
            sw = new StreamWriter(@".\agenda.txt");
            sw.WriteLine(sr.ReadToEnd());
            sr.Close();
            sw.Close();
        }
        // Recuperar Usuari
        static void RecuperarUsuari()
        {
            Console.WriteLine("Digues el nom de quin usuari vols recuperar:");
            string nom = Console.ReadLine();
            while (UsuariTrobat(nom))
            {

            }
        }
        static bool UsuariTrobat(string nom)
        {
            bool trobat = false;    
            StreamReader sr = new StreamReader(@".\agenda.txt");
            if (nom.EndsWith('*'))
            {
                nom = nom.Substring(0, nom.Length - 1);
                
            }
            return trobat;
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
