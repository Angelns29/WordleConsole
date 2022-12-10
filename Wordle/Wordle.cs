/*
* AUTHOR: Angel Navarrete Sanchez
* DATE: 2022/11/30
* DESCRIPTION: Crear un programa que s'assembli al joc Wordle. 
*/
using System;

namespace Wordle
{
    class Wordle
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Benvingut a Wordle");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("- JUGAR");
            Console.WriteLine("- SORTIR");
            Console.Write("Que vols fer: ");
            string opcio = Console.ReadLine();

            if ( opcio.ToUpper() == "JUGAR")
            {
                //INFORMACIO
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("INFORMACIO: ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("WORDLE tracta d'endevinar la paraula en 6 intents. Introdueix paraules de 5 lletres que existeixin i fes clic al boto 'ENTER'.");
                Console.WriteLine("Després de cada intent, el color de les lletres canviarà i et donarà pistes de com estàs de prop d'endevinar la paraula.");
                Console.WriteLine("Exemple:");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("J");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("UGAR \n Si el fons es de color Verd es que la paraula esta ben colocada la lletra");
                Console.Write("J");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("U");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("GAR \n Si el fons es de color Groc es que la paraula esta mal colocada la lletra, pero esta a la paraula");
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("DOTZE");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("Si el fons es de color gris es que no esta la lletra a la paraula");
                Console.WriteLine("Per comezar a jugar clica a ENTER");
                Console.ReadLine();
                Console.Clear();

                //COMENZAMENT DEL WORDLES
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("[Les paraules a trobar i a introduir seran de 5 lletres]");
                Console.ForegroundColor = ConsoleColor.White;
                int intents = 6;
                string[] paraules = { "JUGAR", "MATAR", "FUMAR","DUTXA", "ABRIL", "ABANS", "DIGUI", "PILOT", "DOTZE", "MAGIC", "NUVOL", "DIARI", "CANVI", "FUTUR", "RISCS", "BELAI", "VIRUS", "MASSA", "SADIC", "CIVIL", "FUSIO", "PODAR" , "SONAR", "AFUAR", "BASCA", "AMANT" };
                Random ran = new Random();
                string paraulaATrobar = paraules[ran.Next(0,paraules.Length)];
                string paraulaJugador = string.Empty;
                int contador = 0;
                while(intents != 0)
                {
                    if (intents > 3)
                    {
                        Console.WriteLine("\nIntents: " + intents);
                    }
                    else if (intents > 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nIntents: " + intents);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (intents == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIntents: " + intents);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    
                    Console.WriteLine("Introdueix una Paraula");
                    paraulaJugador = Console.ReadLine();
                    //COMPROVACIO DE LA PARAULA INTRODUIDA
                    while (paraulaJugador.Length < paraulaATrobar.Length || paraulaJugador.Length > 5 )
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("[La paraula a introduir ha de ser de 5 lletres]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Introdueix una Paraula");
                        paraulaJugador = Console.ReadLine();
                    }
                    foreach (char lletra in paraulaJugador)
                    {
                        while (lletra < 65 || lletra > 122)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("[La paraula no pot contenir numeros ni caracters especials]");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Introdueix una Paraula");
                            paraulaJugador = Console.ReadLine();
                            break;
                        }
                    }

                    for (int i = 0; i < paraulaATrobar.Length; i++)
                    {
                        if (paraulaATrobar.ToUpper()[i] == paraulaJugador.ToUpper()[i])
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(paraulaJugador.ToUpper()[i] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            contador++;
                        }
                        else if (paraulaATrobar.ToUpper().Contains(paraulaJugador.ToUpper()[i])){
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(paraulaJugador.ToUpper()[i] + " ");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;

                        }
                        else if (paraulaATrobar.ToUpper()[i] != paraulaJugador.ToUpper()[i])
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(paraulaJugador.ToUpper()[i] + " ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }
                        
                    }
                    intents--;
                    if (contador == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nFELICITATS HAS TROBAT LA PARAULA");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                        /*
                        Console.WriteLine("Vols tornar a jugar o sortir");
                        opcio = Console.ReadLine();
                        intents = 6;
                        Console.Clear();*/
                    }
                    contador = 0;
                    if (intents == 0) {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nIntents Esgotats");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("La Paraula era: " + paraulaATrobar);
                        /*
                        Console.WriteLine("Vols tornar a jugar o sortir");
                        opcio = Console.ReadLine();
                        intents = 6;
                        Console.Clear();
                        */
                    }
                    
                }
                
            }
            else
            {
                Console.WriteLine("Gracies per jugar");
                Console.WriteLine("Fet per Angel Navarrete");
            }
        }
    }
}
