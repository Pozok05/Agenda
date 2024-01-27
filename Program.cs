using System.Linq.Expressions;
using System.Net;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                    RecuperarUsuari();
                    break;
                case '3':
                    ModificarUsuari();
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
            nom = NomVerificat(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Escriu el teu cognom1:");
            cognom1 = NomVerificat(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Escriu el teu cognom2:");
            cognom2 = NomVerificat(Console.ReadLine());
            Console.Clear();
            dni = VerificaDni();
            telefon = VerificaTelefon();
            DateTime dateNaixement;
            dataNaixement = VerificaDataNaixement(out dateNaixement);
            correu = VerificaCorreu();
            persona = $"{nom},{cognom1},{cognom2},{dni},{telefon},{dataNaixement},{correu}";
            EscriuUsuariFitxer(persona);
            Console.Clear();
            Console.WriteLine(UsuariAmigable(persona));
            //Console.WriteLine($"Nom: {nom}\tCognom1: {cognom1}\tCognom2: {cognom2}\nDni: {dni}\tTelefon: {telefon}\nData naixement: {dataNaixement}\tEdat: {CalcularEdat(dateNaixement)} anys\nCorreu: {correu}");
            Thread.Sleep(30000);
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
            nom = nom.ToLower().Trim();
            for (int i = 0; i < nom.Length; i++)
            {
                if (char.IsLetter(nom[i]))
                {
                    res += nom[i];
                }
            }
            if(res.Length != 0)
                res = res.Substring(0,1).ToUpper() + res.Substring(1);               
            return res;
        }
        static string VerificaDni()
        {
            string dni;
            Console.Clear();
            Console.WriteLine("Escriu un dni valid:");
            dni = Console.ReadLine();
            while (!DniValid(dni))
            {
                Console.Clear();
                Console.WriteLine("El dni esta mal escrit, recorda que es format 123455678A");
                Console.WriteLine("Escriu un dni valid:");
                dni = Console.ReadLine();
            }
            return dni;
        }
        static bool DniValid(string dni)
        {

            string dniChars = "TRWAGMYFPDXBNJZSQVHLCKET";
            Regex regexDni = new Regex("^[0-9]{8}[TRWAGMYFPDXBNJZSQVHLCKET]$");
            bool valid = regexDni.IsMatch(dni);
            if (valid)
            {
                char c = dni[dni.Length - 1];
                if (!(c == dniChars[Convert.ToInt32(dni.Substring(0, dni.Length - 1)) % 23]))
                {
                    valid = false;
                }
            }
            return valid;
        }
        static string VerificaTelefon()
        {
            string telefon = "";
            int aux = 0;
            Console.Clear();
            Console.WriteLine("Escriu un telefon valid:");
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
        
        static string VerificaDataNaixement(out DateTime resultat)
        {
            string datanaixement;
            Console.Clear();
            Console.WriteLine("Escriu una data de naixement valida:");
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
            Console.WriteLine("Escriu un correu electronic valid:");
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
            string nom, res, pregunta;
            //char continuar;
            do
            {
                Console.Clear();
                Console.WriteLine("Digues el nom del usuari que vols recuperar:");
                nom = Console.ReadLine().Trim();
                res = "";
                pregunta = "";
                //continuar = 'N';
                if (nom.EndsWith('*'))
                {
                    nom = NomVerificat(nom);
                    res = UsuarisTrobatsAsterisc(nom);
                }
                else
                {
                    nom = NomVerificat(nom);
                    res = UsuariTrobat(nom);
                }
                if(res == "0")
                {
                    pregunta = $"No s'ha trobat l'usuari amb el nom {nom}\n";
                    //do
                    //{
                    //    Console.Clear();
                    //    Console.WriteLine($"No s'ha trobat l'usuari amb el nom {nom}\nVols buscar un altre(S/N)?");
                    //    continuar = Convert.ToChar(Console.ReadLine()[0]);
                    //}
                    //while (continuar != 'N' && continuar != 'S');
                }
                else
                {
                    while (res.Contains($"\n"))
                    {
                        Console.WriteLine(UsuariAmigable(res.Substring(0,res.IndexOf($"\n"))));
                        res = res.Substring(res.IndexOf($"\n") + 1);
                    }
                    Console.WriteLine(UsuariAmigable(res));
                    Thread.Sleep(10000);
                }
                pregunta += "Vols buscar un altre?";

            }
            while (PreguntaContinuar(pregunta));
        }
        static string UsuariTrobat(string nom)
        {
            string res = "0", linia;
            StreamReader sr = new StreamReader(@".\agenda.txt");
            while(!sr.EndOfStream && res == "0")
            {
                linia = sr.ReadLine();
                if(nom == linia.Substring(0,linia.IndexOf(',')))
                    res = linia;
            }
            sr.Close();
            return res;
        }
        static string UsuarisTrobatsAsterisc(string nom)
        {
            string res = "0", linia;
            StreamReader sr = new StreamReader(@".\agenda.txt");
            while (!sr.EndOfStream)
            {
                linia = sr.ReadLine();
                if (linia.Substring(0, linia.IndexOf(',')).StartsWith(nom))
                {
                    if (res == "0")
                        res = linia;
                    else res += $"\n{linia}";
                }
            }
            sr.Close();
            return res;
        }
        //Es fa servir per mostrar de forma amigable
        static string UsuariAmigable(string linia)
        {
            string s = "";
            string[] titols = ["Nom", "Cognom1", "Cognom2", "Dni", "Telefon", "Data de naixament", "Edat", "Correu"];
            for(int i = 0; i < 6; i++)
            {
                s += $"{titols[i]}: {linia.Substring(0, linia.IndexOf(","))} \t";
                if (i > 0 && i % 2 == 0) // Ves fent intros pq quedi bonic
                    s += "\n";
                if(i != 5)
                    linia = linia.Substring(linia.IndexOf(",") + 1);
            }
            /*int[] dates = new int[3];
            dates[0] = Convert.ToInt32(linia.Substring(0, linia.IndexOf("/")));
            linia = linia.Substring(linia.IndexOf("/") + 1);
            dates[1] = Convert.ToInt32(linia.Substring(0, linia.IndexOf("/")));
            linia = linia.Substring(linia.IndexOf("/") + 1);
            dates[2] = Convert.ToInt32(linia.Substring(0, linia.IndexOf("/")));
            linia = linia.Substring(linia.IndexOf("/") + 1);
            s += $"{titols[6]}: {CalcularEdat(new DateTime(dates[0], dates[1], dates[2]))}";
            */
            s += $"{titols[6]}: {CalcularEdat(StringDataNaixementToDateTime(linia))}\n";
            linia = linia.Substring(linia.IndexOf(",") + 1);
            s += $"{titols[7]}: {linia}";
            return s;
        }
        static DateTime StringDataNaixementToDateTime(string linia)
        {
            int[] dates = new int[3];
            dates[0] = Convert.ToInt32(linia.Substring(0, linia.IndexOf(@"/")));
            linia = linia.Substring(linia.IndexOf(@"/") + 1);
            dates[1] = Convert.ToInt32(linia.Substring(0, linia.IndexOf(@"/")));
            linia = linia.Substring(linia.IndexOf(@"/") + 1);
            dates[2] = Convert.ToInt32(linia.Substring(0, linia.IndexOf(",")));

            return new DateTime(dates[2], dates[1], dates[0]);
        }
        static void ModificarUsuari()
        {
            string nom, modificacio, linia, pregunta;
            char continuar = 'S';
            //Troba usuari
            Console.WriteLine("Digues el nom del usuari que vols modificar:");
            nom = NomVerificat(Console.ReadLine());
            linia = UsuariTrobat(nom);
            while (linia == "0")
            {
                Console.WriteLine($"No s'ha trobat l'usuari amb nom: {nom}");
                Console.WriteLine("Digues el nom del usuari que vols modificar:");
                nom = NomVerificat(Console.ReadLine());
                linia = UsuariTrobat(nom);
            }
            do
            {
                //Troba que vols modificar
                Console.Clear();
                Console.WriteLine("Les dades del usuari són les següents:");
                Console.WriteLine("(nom,cognom1,cognom2,dni,telefon,data de naixement,correu)");
                Console.WriteLine(UsuariAmigable(linia));
                Console.WriteLine("Digues quina dada vols modificar");
                modificacio = Console.ReadLine();
                while(TrobarNumDada(modificacio) == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Dada no valida, escriu una de les següents:");
                    Console.WriteLine("(nom,cognom1,cognom2,dni,telefon,data de naixement,correu)");
                    Console.WriteLine($"Usuari: \n{UsuariAmigable(linia)}");
                    Console.WriteLine("Digues quina dada vols modificar");
                    modificacio = Console.ReadLine();
                }
                int i = TrobarNumDada(modificacio);
                ModificarDadaUsuari(ref linia,i);
                pregunta = $"Vols seguir modificant aquest usuari? \nUsuari: \n{UsuariAmigable(linia)}";
                //Console.WriteLine("Vols seguir modificant aquest usuari(S/N)?");
                //Console.WriteLine($"Usuari: \n{UsuariAmigable(linia)}");
                //continuar = Convert.ToChar(Console.ReadLine()[0]);
            }
            while (PreguntaContinuar(pregunta));
        }
        static int TrobarNumDada(string nomDada)
        {
            int num = -1;
            nomDada = nomDada.Trim().ToLower();
            switch (nomDada)
            {
                case "nom":
                    num = 0;
                    break;
                case "cognom1":
                    num = 1;
                    break;
                case "cognom2":
                    num = 2;
                    break;
                case "dni":
                    num = 3;
                    break;
                case "telefon":
                    num = 4;
                    break;
                case "data de naixement":
                    num = 5;
                    break;
                case "correu":
                    num = 6;
                    break;
                default:
                    num = -1; 
                    break;
            }
            return num;
        }
        static void ModificarDadaUsuari(ref string liniaUsuari, int posModificacio)
        {
            StreamReader sr = new StreamReader(@".\agenda.txt");
            StreamWriter sw = new StreamWriter(@".\aux.txt");
            string liniaActual = sr.ReadLine();
            string novaDada = "";
            while(liniaActual != liniaUsuari) 
            {
                sw.WriteLine(liniaActual);
                liniaActual = sr.ReadLine();
            }
            if( liniaActual == liniaUsuari) //Es redundant pero en cas que hi hagi algun error inesperat no hi entra
            {
                switch (posModificacio)
                {
                    case 0:
                        Console.WriteLine("Escriu un nom valid:");
                        novaDada = NomVerificat(Console.ReadLine());
                        break;
                    case 1:
                        Console.WriteLine("Escriu un cognom1 valid:");
                        novaDada = NomVerificat(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Escriu un cognom2 valid:");
                        novaDada = NomVerificat(Console.ReadLine());
                        break;
                    case 3:
                        novaDada = VerificaDni();
                        break;
                    case 4:
                        novaDada = VerificaTelefon();
                        break;
                    case 5:
                        novaDada = VerificaDataNaixement(out DateTime resultat);
                        break;
                    case 6:
                        novaDada = VerificaCorreu();
                        break;
                    default:
                        throw new Exception("Hi ha algun error amb la posicio de la modificacio");
                        break;
                }
                string liniaAnterior, liniaPosterior;
                liniaActual = "";
                for (int i = 0; i < posModificacio; i++)
                {
                    liniaActual += liniaUsuari.Substring(0, liniaUsuari.IndexOf(',')+1);
                    liniaUsuari = liniaUsuari.Substring(liniaUsuari.IndexOf(',') + 1);
                }
                if(posModificacio != 6)
                    liniaUsuari = liniaUsuari.Substring(liniaUsuari.IndexOf(',') + 1);
                liniaActual += $"{novaDada},{liniaUsuari}";
                liniaUsuari = liniaActual;
            }
            while (!sr.EndOfStream)
            {
                sw.WriteLine(liniaActual);
                liniaActual = sr.ReadLine();
            }
            sr.Close();
            sw.Close();
            sr = new StreamReader(@".\aux.txt");
            sw = new StreamWriter(@".\agenda.txt");
            sw.Write(sr.ReadToEnd());
            sr.Close();
            sw.Close();
            
        }
        static bool PreguntaContinuar(string pregunta)
        {
            char opcio = ' ';
            Console.Clear();
            Console.WriteLine($"Respon amb S o N\n{pregunta}");
            opcio = Convert.ToChar(Console.ReadLine()[0]);
            while (opcio != 'N' && opcio != 'S' && opcio != 'n' && opcio != 's')
            {
                Console.Clear();
                Console.WriteLine("No has escrit be, respon amb S o N");
                Console.WriteLine(pregunta);
                opcio = Convert.ToChar(Console.ReadLine()[0]);
            }
            return (opcio == 'S' || opcio == 's');
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
