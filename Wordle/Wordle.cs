/*
* AUTHOR: Angel Navarrete Sanchez
* DATE: 2022/02/07
* DESCRIPTION: Parametrtzacio y utilitzacio de Fitxers al Wordle Creat
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace Wordle
{
    public class Wordle
    {
        public static void Main()
        {
            Wordle app = new Wordle();
            app.WordleGame();
        }

        /// <summary>
        /// Metode Principal de l'aplicació
        /// </summary>
        /// <remarks>Idioma per defecte: Català</remarks>
        void WordleGame()
        {
            bool endGame;
            string idioma = "cat";
            do
            {
                WordleTitle();
                MostrarOpcions(idioma);
                endGame = EscollirOpcio(ref idioma);
            } while (endGame == false);

        }
        /// <summary>
        /// Funcio que imprimeix els idiomes que hi ha actualment implementats a l'aplicació
        /// </summary>
        /// <param name="pathFitxer">Ubicacio del fitxer de configuracio d'idioma</param>
        /// <returns>Un Array d'string per fer el tractament de l'idioma</returns>
        string[] ImprimirIdiomes(string pathFitxer)
        {
            StreamReader sr = File.OpenText(pathFitxer);
            string[] idiomes = sr.ReadToEnd().Replace("\r\n", " ").Split(':', ' ');
            for (int i = 0; i < idiomes.Length; i += 2)
            {
                Console.WriteLine("- " + idiomes[i].ToUpper());
            }
            sr.Close();
            return idiomes;
        }

        /// <summary>
        /// Demana al usuari un idioma
        /// </summary>
        /// <param name="idioma">Segons l'idioma printarà en un idioma o un altre</param>
        /// <returns>Torna l'idioma que ha escollit l'usuari</returns>
        public string DemanarIdioma(ref string idioma)
        {
            if (idioma == "es") Console.WriteLine("Idioma por defecto: Catalan");
            else if (idioma == "en") Console.WriteLine("Default language: Catalan");
            else if (idioma == "cat") Console.WriteLine("Idioma per defecte: Català");
            string[] idiomes = ImprimirIdiomes("../../../config.txt");
            for (int i = 0; i < idiomes.Length; i += 2)
            {
                Console.WriteLine("- " + idiomes[i]);
            }
            Console.Write("Escull una opció: ");
            string opcio = Console.ReadLine().Replace("à", "a").Replace("è", "e");
            Console.Clear();
            return opcio;
        }

        /// <summary>
        /// Metode per cambiar d'idioma
        /// </summary>
        /// <param name="idioma">Es pasa per referencia la variable idioma on per defecte es Català</param>
        /// <returns>Retorna un string segons l'idioma: es, en o cat</returns>
        public string SetIdioma(ref string idioma, string opcio)
        {
            string[] idiomes = ImprimirIdiomes("../../../config.txt");
            for (int i = 0; i < idiomes.Length; i += 2)
            {
                if (opcio.ToUpper() == idiomes[i].ToUpper())
                {
                    idioma = idiomes[i + 1];
                    return idioma;
                }
                else
                {
                    idioma = "cat";
                }
            }
            return idioma;
        }

        /// <summary>
        /// Metode que mostra  el títol del Worlde.  
        /// No retorna res.
        /// </summary>
        void WordleTitle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\t\t   " + @"           .---.                              ,--,              ");
            Console.WriteLine("\t\t\t   " + @"          /. ./|                       ,---,,--.'|              ");
            Console.WriteLine("\t\t\t   " + @"      .--'.  ' ;   ,---.    __  ,-.  ,---.'||  | :              ");
            Console.WriteLine("\t\t\t   " + @"     /__./ \ : |  '   ,'\ ,' ,'/ /|  |   | ::  : '              ");
            Console.WriteLine("\t\t\t   " + @" .--'.  '   \' . /   /   |'  | |' |  |   | ||  ' |      ,---.   ");
            Console.WriteLine("\t\t\t   " + @"/___/ \ |    ' '.   ; ,. :|  |   ,',--.__| |'  | |     /     \  ");
            Console.WriteLine("\t\t\t   " + @";   \  \;      :'   | |: :'  :  / /   ,'   ||  | :    /    /  | ");
            Console.WriteLine("\t\t\t   " + @" \   ;  `      |'   | .; :|  | ' .   '  /  |'  : |__ .    ' / | ");
            Console.WriteLine("\t\t\t   " + @"  .   \    .\  ;|   :    |;  : | '   ; |:  ||  | '.'|'   ;   /| ");
            Console.WriteLine("\t\t\t   " + @"   \   \   ' \ | \   \  / |  , ; |   | '/  ';  :    ;'   |  / | ");
            Console.WriteLine("\t\t\t   " + @"    :   '  |--" + "    '----'   ---'  |   :    :||  ,   / |   :    | ");
            Console.WriteLine("\t\t\t   " + @"     \   \ ;                      \   \  /   ---`-'   \   \  /  ");
            Console.WriteLine("\t\t\t   " + @"      '---" + "                         `----'              `----'");
            Console.WriteLine();
        }
        /// <summary>
        /// Mostra per pantalla les opcions a l'aplicació
        /// </summary>
        /// <param name="idioma">Segons l'idioma de la variable mostrarà una cosa o un altre</param>
        void MostrarOpcions(string idioma)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (idioma)
            {
                case "es":
                    Console.WriteLine("Idioma: Español");
                    Console.WriteLine("1- JUGAR");
                    Console.WriteLine("2- HISTORICO DE JUGADORES");
                    Console.WriteLine("3- CAMBIAR IDIOMA");
                    Console.WriteLine("4- SALIR");
                    break;
                case "en":
                    Console.WriteLine("Language: English");
                    Console.WriteLine("1- PLAY");
                    Console.WriteLine("2- PLAYER'S HISTORY");
                    Console.WriteLine("3- CHANGE LANGUAGE");
                    Console.WriteLine("4- EXIT");
                    break;
                case "cat":
                    Console.WriteLine("Llenguatge: Catala");
                    Console.WriteLine("1- JUGAR");
                    Console.WriteLine("2- HISTÒRIC DE JUGADORS");
                    Console.WriteLine("3- CAMBIAR IDIOMA");
                    Console.WriteLine("4- SORTIR");
                    break;
            }
        }

        public bool EscollirOpcio(ref string idioma)
        {
            bool endGame = false;
            int resultat = 0;
            if (idioma == "es")
            {
                Console.Write("Que quieres hacer: ");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "1":
                        Console.Clear();
                        Console.ReadLine();
                        WordlePlay(idioma, resultat);
                        break;
                    case "2":
                        MostrarHistoricJugadors(idioma);
                        break;
                    case "3":
                        string opcioIdioma = DemanarIdioma(ref idioma);
                        SetIdioma(ref idioma, opcioIdioma);
                        break;
                    case "4":
                        PrintImage("../../../lang/", idioma + "/goodbye.txt");
                        Console.WriteLine("Hecho por Angel Navarrete");
                        endGame = true;
                        break;
                    default:
                        Console.WriteLine("Opcion Incorrecta");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            else if (idioma == "en")
            {
                Console.Write("What do you want to do: ");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "1":
                        WordlePlay(idioma, resultat);
                        break;
                    case "2":
                        MostrarHistoricJugadors(idioma);
                        break;
                    case "3":
                        string opcioIdioma = DemanarIdioma(ref idioma);
                        SetIdioma(ref idioma, opcioIdioma);
                        break;
                    case "4":
                        PrintImage("../../../lang/", idioma + "/goodbye.txt");
                        Console.WriteLine("Made by Angel Navarrete");
                        endGame = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect option");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            else if (idioma == "cat")
            {
                Console.Write("Que vols fer: ");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "1":
                        WordlePlay(idioma, resultat);
                        break;
                    case "2":
                        MostrarHistoricJugadors(idioma);
                        break;
                    case "3":
                        string opcioIdioma = DemanarIdioma(ref idioma);
                        SetIdioma(ref idioma, opcioIdioma);
                        break;
                    case "4":
                        PrintImage("../../../lang/", idioma + "/goodbye.txt");
                        Console.WriteLine("Fet per Angel Navarrete");
                        endGame = true;
                        break;
                    case "1987":
                        Console.Clear();
                        PrintImage("../../../lang/", "easteregg.txt");
                        Console.ReadLine();
                        endGame = true;
                        break;
                    default:
                        Console.WriteLine("Opcio Incorrecta");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            return endGame;
        }

        /// <summary>
        /// Funcio de l'opcio de JUGAR on comença el Wordle
        /// </summary>
        /// <param name="idioma">Segons l'idioma, mostrarà en un idioma o un altre</param>
        /// <param name="resultat">variable emb les vagades que l'usuari ha encertat la paraula</param>
        /// <returns>Retorna la variable resultat amb les vegades que ha encertat la paraula</returns>
        public int WordlePlay(string idioma, int resultat)
        {
            //INFORMACIO
            Informacio(idioma);

            //ADVERTENCIA DE FORMAT
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (idioma == "es") Console.WriteLine("[Las palabras a encontrar y a introducir son de 5 letras]");
            else if (idioma == "en") Console.WriteLine("[The words to be found and entered will be 5 letters long]");
            else if (idioma == "cat") Console.WriteLine("[Les paraules a trobar i a introduir seran de 5 lletres]");
            Console.ForegroundColor = ConsoleColor.White;

            int intents = 6;
            string paraulaATrobar = GenerarParaulaAleatoria(idioma);
            Console.WriteLine(paraulaATrobar);

            string paraulaJugador = string.Empty;
            int contadorLetrasCorrectas = 0;

            while (intents != 0)
            {
                MostrarIntents(idioma, intents);
                bool paraulaCorrecta = false;
                do
                {
                    if (paraulaCorrecta == false || paraulaJugador == string.Empty)
                    {
                        Console.WriteLine("Introduce palabrita magica");
                        paraulaCorrecta = IntroduirParaula(idioma, paraulaATrobar, ref paraulaJugador);
                    }
                    paraulaCorrecta = ComprovarCaractersParaulaJugador(paraulaJugador);

                } while (paraulaCorrecta == false || paraulaJugador == string.Empty);



                contadorLetrasCorrectas = MostrarParaula(paraulaJugador, paraulaATrobar, contadorLetrasCorrectas);
                intents--;
                if (contadorLetrasCorrectas == 5)
                {
                    WordleWin(idioma);
                    resultat++;
                    PlayAgain(idioma, resultat);
                }
                contadorLetrasCorrectas = 0;
                //paraulaJugador = string.Empty;
                if (intents == 0)
                {
                    WordleLose(paraulaATrobar, idioma);
                    PlayAgain(idioma, resultat);
                }
            }
            return resultat;
        }

        /// <summary>
        /// Funcio que Demana una paraula a l'usuari i comprova si te la llargada necessària.
        /// </summary>
        /// <param name="idioma">Segons l'idioma mostrarà en un idioma o un altre</param>
        /// <param name="paraulaATrobar">Paraula Genrada aleatoriament per el programa</param>
        /// <returns>Retorna la paraula introduida per el jugador correctament formatejada</returns>
        public bool IntroduirParaula(string idioma, string paraulaATrobar, ref string paraulaJugador)
        {
            paraulaJugador = Console.ReadLine();
            //COMPROVACIO DE LA PARAULA INTRODUIDA
            bool correcte = true;
            if (paraulaJugador.Length < paraulaATrobar.Length || paraulaJugador.Length > 5)
            {
                CambiarColor("COLOR", ConsoleColor.Yellow);
                if (idioma == "es") Console.WriteLine("[La palabra a introducir ha de ser de 5 letras]");
                else if (idioma == "en") Console.WriteLine("[The word to enter must be 5 letters]");
                else if (idioma == "cat") Console.WriteLine("[La paraula a introduir ha de ser de 5 lletres]");
                CambiarColor("COLOR", ConsoleColor.White);
                //paraulaJugador = "error";
                correcte = false;
            }
            return correcte;
        }

        /// <summary>
        /// Funcio que escull la paraula aleatoriament entre les 100 que hi ha en el fitxer.
        /// </summary>
        /// <param name="idioma">Segons el idioma introduït, escollirà un fitxer o altre amb paraules dels diferents idiomes.</param>
        /// <returns>Retorna un string amb la paraula aleatoria</returns>
        string GenerarParaulaAleatoria(string idioma)
        {
            //string[] paraules = {"JUGAR", "MATAR", "FUMAR", "DUTXA", "ABRIL", "ABANS", "DIGUI", "PILOT", "DOTZE", "MAGIC", "NUVOL", "DIARI", "CANVI", "FUTUR", "RISCS", "BELAI", "VIRUS", "MASSA", "SADIC", "CIVIL", "FUSIO", "PODAR", "SONAR", "AFUAR", "BASCA", "AMANT"  };
            List<string> paraules = new List<string>();
            StreamReader sr = File.OpenText("../../../lang/" + idioma + "/words.txt");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                paraules.Add(line);
            }
            Random ran = new Random();
            string paraulaATrobar = paraules[ran.Next(0, paraules.Count)];
            sr.Close();
            return paraulaATrobar;
        }

        /// <summary>
        /// Funcio que imprimeix per pantalla el intents restants.
        /// </summary>
        /// <param name="idioma">Segons l'idioma motrarà en un idioma o un altre</param>
        /// <param name="intents">Quantitat d'intents restants</param>
        /// <returns>Retorna la quantitat de intents restants</returns>
        public int MostrarIntents(string idioma, int intents)
        {
            if (intents > 3)
            {
                CambiarColor("FONS", ConsoleColor.Black);
                CambiarColor("COLOR", ConsoleColor.White);
                if (idioma == "es") Console.WriteLine("\nIntentos: " + intents);
                else if (idioma == "en") Console.WriteLine("\nAttempts: " + intents);
                else if (idioma == "cat") Console.WriteLine("\nIntents: " + intents);
            }
            else if (intents > 1)
            {
                CambiarColor("COLOR", ConsoleColor.Yellow);
                CambiarColor("FONS", ConsoleColor.Black);
                if (idioma == "es") Console.WriteLine("\nIntentos: " + intents);
                else if (idioma == "en") Console.WriteLine("\nAttempts: " + intents);
                else if (idioma == "cat") Console.WriteLine("\nIntents: " + intents);
                CambiarColor("COLOR", ConsoleColor.White);
                CambiarColor("FONS", ConsoleColor.Black);
            }
            else if (intents == 1)
            {
                CambiarColor("FONS", ConsoleColor.Black);
                CambiarColor("COLOR", ConsoleColor.Red);
                if (idioma == "es") Console.WriteLine("\nIntentos: " + intents);
                else if (idioma == "en") Console.WriteLine("\nAttempts: " + intents);
                else if (idioma == "cat") Console.WriteLine("\nIntents: " + intents);
                CambiarColor("COLOR", ConsoleColor.White);

            }
            return intents;
        }
        /// <summary>
        /// Funcio que Controla que la paraula introduida sigui sense caracers especials (. , ; ñ ç etc...).
        /// </summary>
        /// <param name="paraulaJugador">Paraula introduïda inicialment per l'usuari</param>
        /// <returns>Retorna la paraula correctament formatejada</returns>
        public bool ComprovarCaractersParaulaJugador(string paraulaJugador)
        {
            bool correcte = true;
            foreach (char lletra in paraulaJugador)
            {
                while (lletra < 65 || lletra > 122)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("[La paraula no pot contenir numeros ni caracters especials]");
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.WriteLine("Introdueix una Paraula");
                    //paraulaJugador = Console.ReadLine();
                    //break;
                    //return "error";
                    correcte = false;
                    return correcte;
                }
            }
            return correcte;
        }

        /// <summary>
        /// Funcio que compara la paraula a trobar i la paraula introduïda per l'usuari i ho mostra per pantalla.
        /// </summary>
        /// <param name="paraulaJugador">Paraula del Jugador</param>
        /// <param name="paraulaATrobar">Paraula a Trobar generada aleatoriament</param>
        /// <param name="contador"> Variable que compta cuantes posicions estan correctes</param>
        /// <returns>Retorna la Variable contador que son les posicions correctes de la paraula del jugador.</returns>
        public int MostrarParaula(string paraulaJugador, string paraulaATrobar, int contador)
        {
            for (int i = 0; i < paraulaATrobar.Length; i++)
            {
                if (paraulaATrobar.ToUpper()[i] == paraulaJugador.ToUpper()[i])
                {
                    CambiarColor("FONS", ConsoleColor.Green);
                    Console.Write(paraulaJugador.ToUpper()[i] + " ");
                    CambiarColor("FONS", ConsoleColor.Black);
                    contador++;
                }
                else if (paraulaATrobar.ToUpper().Contains(paraulaJugador.ToUpper()[i]))
                {
                    CambiarColor("FONS", ConsoleColor.Yellow);
                    CambiarColor("COLOR", ConsoleColor.Black);
                    Console.Write(paraulaJugador.ToUpper()[i] + " ");
                    CambiarColor("FONS", ConsoleColor.Black);
                    CambiarColor("COLOR", ConsoleColor.White);

                }
                else if (paraulaATrobar.ToUpper()[i] != paraulaJugador.ToUpper()[i])
                {
                    CambiarColor("FONS", ConsoleColor.Gray);
                    CambiarColor("COLOR", ConsoleColor.Black);
                    Console.Write(paraulaJugador.ToUpper()[i] + " ");
                    CambiarColor("FONS", ConsoleColor.White);
                    CambiarColor("COLOR", ConsoleColor.Black);
                }

            }
            return contador;
        }

        /// <summary>
        /// Funcio que es mostrarà si el jugador guanya la partida
        /// </summary>
        /// <param name="idioma">Segons l'idioma mostrarà en un idioma o un altre</param>
        void WordleWin(string idioma)
        {
            Console.Clear();
            PrintImage("../../../lang/" + idioma + "/", "win.txt");
            CambiarColor("COLOR", ConsoleColor.Green);
            if (idioma == "es") Console.WriteLine("\n FELICIDADES HAS ENCONTRADO LA PALABRA");
            else if (idioma == "en") Console.WriteLine("\n CONGRATULATIONS YOU FIND THE WORD");
            else if (idioma == "cat") Console.WriteLine("\n FELICITATS HAS TROBAT LA PARAULA");
            CambiarColor("COLOR", ConsoleColor.White);
        }

        /// <summary>
        /// Funció que es mostrarà si el jugador perd la partida
        /// </summary>
        /// <param name="paraulaATrobar">Paraula a que l'usuari habia d'endevinar y es aleatòria</param>
        /// <param name="idioma">Segons l'idioma mostrarà en un idioma o un altre</param>
        void WordleLose(string paraulaATrobar, string idioma)
        {
            if (idioma == "es")
            {
                CambiarColor("FONS", ConsoleColor.Black);
                Console.Clear();
                CambiarColor("COLOR", ConsoleColor.White);
                PrintImage("../../../lang/" + idioma + "/", "lose.txt");
                CambiarColor("COLOR", ConsoleColor.Red);
                Console.WriteLine("\nIntentos Agotados");
                Console.ForegroundColor = ConsoleColor.White;
                CambiarColor("COLOR", ConsoleColor.White);
                Console.WriteLine("La Palabra era: " + paraulaATrobar);
            }
            else if (idioma == "en")
            {
                CambiarColor("FONS", ConsoleColor.Black);
                Console.Clear();
                CambiarColor("COLOR", ConsoleColor.White);
                PrintImage("../../../lang/" + idioma + "/", "lose.txt");
                CambiarColor("COLOR", ConsoleColor.Red);
                Console.WriteLine("\nAttempts exhausted");
                CambiarColor("COLOR", ConsoleColor.White);
                Console.WriteLine("The Word was: " + paraulaATrobar);
            }
            else if (idioma == "cat")
            {
                CambiarColor("FONS", ConsoleColor.Black);
                Console.Clear();
                CambiarColor("COLOR", ConsoleColor.White);
                PrintImage("../../../lang/" + idioma + "/", "lose.txt");
                CambiarColor("COLOR", ConsoleColor.Red);
                Console.WriteLine("\nIntents Esgotats");
                CambiarColor("COLOR", ConsoleColor.White);
                Console.WriteLine("La Paraula era: " + paraulaATrobar);
            }
        }

        /// <summary>
        /// Funcio que al finalitzar la partida pregunta al jugador si vol tornar a jugar o no.
        /// </summary>
        /// <param name="idioma">Segons l'idioma mostrarà en un idioma o un altre</param>
        /// <param name="resultat">Resultat total de paraules endevinades</param>
        /// <returns>Retorna un boleà si vol tornar a jugar o no</returns>
        bool PlayAgain(string idioma, int resultat)
        {
            bool playagain = false;
            if (idioma == "es")
            {
                Console.WriteLine("Quieres volver a jugar o salir");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "JUGAR":
                        playagain = true;
                        WordlePlay(idioma, resultat);
                        break;
                    case "SALIR":
                        InsertarResultatJugador(resultat, idioma);
                        PrintImage("../../../lang/" + idioma + "/", "goodbye.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcion Incorrecta");
                        PlayAgain(idioma, resultat);
                        break;
                }
            }
            else if (idioma == "en")
            {
                Console.WriteLine("Do you want to play again or quit");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "PLAY":
                    case "PLAYAGAIN":
                    case "PLAY AGAIN":
                        playagain = true;
                        WordlePlay(idioma, resultat);
                        break;
                    case "QUIT":
                    case "EXIT":
                        InsertarResultatJugador(resultat, idioma);
                        PrintImage("../../../lang/" + idioma + "/", "_goodbye.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect Option");
                        PlayAgain(idioma, resultat);
                        break;
                }
            }
            else if (idioma == "cat")
            {
                Console.WriteLine("Vols tornar a jugar o sortir");
                string opcio = Console.ReadLine();
                switch (opcio.ToUpper())
                {
                    case "JUGAR":
                        playagain = true;
                        WordlePlay(idioma, resultat);
                        break;
                    case "SORTIR":
                        InsertarResultatJugador(resultat, idioma);
                        PrintImage("../../../lang/" + idioma + "/", "_goodbye.txt");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opcio Incorrecta");
                        PlayAgain(idioma, resultat);
                        break;
                }
            }


            return playagain;
        }

        /// <summary>
        /// Funcio que introdueix el resultat de la partida i el nom del jugador (que ho demana al jugador), a un fitxer anomenat players_history.\n
        /// </summary>
        /// <param name="resultat">Quantitat de paraules endevinbades</param>
        /// <param name="idioma"> Segons l'idioma preguntarà al jugador en un idioma o en un altre</param>
        public void InsertarResultatJugador(int resultat, string idioma)
        {
            if (idioma == "es") Console.Write("Introduce tu nombre: ");
            else if (idioma == "en") Console.Write("Enter your name: ");
            else if (idioma == "cat") Console.Write("Introdueix el teu nom: ");

            string nombre = Console.ReadLine();
            do
            {
                if (nombre.Length == 0)
                {
                    if (idioma == "es") Console.WriteLine("\n No has escrito un nombre");
                    else if (idioma == "en") Console.WriteLine("\n You have not entered a name");
                    else if (idioma == "cat") Console.WriteLine("\n No has escrit cap nom");
                    nombre = Console.ReadLine();
                }
            } while (nombre.Length == 0);
            StreamWriter history;
            if (!File.Exists("../../../lang/players_history.txt"))
            {
                history = new StreamWriter("../../../lang/players_history.txt");
            }
            else
            {
                history = File.AppendText("../../../lang/players_history.txt");
            }
            history.WriteLine(nombre + ":" + resultat);
            history.Close();
        }

        /// <summary>
        /// Funcio per mostrar l'historic dels jugador que han jugat al Wordle
        /// </summary>
        /// <example>Angel:5, on mostra el nom del participant o el pseudonim que vulgui posar y el numero es la quantitat de paraules endevinades</example>
        /// <param name="idioma">Segons el idioma introduït ho mostrarà en un idioma</param>
        void MostrarHistoricJugadors(string idioma)
        {
            Console.Clear();
            if (idioma == "es") Console.WriteLine("\n Historico de Jugadores: \n");
            else if (idioma == "en") Console.WriteLine("\n Player's History \n");
            else if (idioma == "cat") Console.WriteLine("\n Historic de Jugadors \n");
            StreamReader historicJugadors = File.OpenText("../../../lang/players_history.txt");
            string line;
            while ((line = historicJugadors.ReadLine()) != null)
            {
                Console.WriteLine("\t" + line);
            }
            historicJugadors.Close();
            if (idioma == "es") Console.WriteLine("\n Pulsa cualquier tecla para volver al Menu: ");
            else if (idioma == "en") Console.WriteLine("\n Press any key to return to the Menu");
            else if (idioma == "cat") Console.WriteLine("\n Pulsa qualsevol tecla per tornar al Menu");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Metode que mostra per pantalla informacio sobre el funcionament del Wordle.
        /// </summary>
        /// <param name="idioma">Parametre amb el cual imprimirà en el idioma escollit per l'usuari</param>
        void Informacio(string idioma)
        {
            StreamReader informacio = File.OpenText("../../../lang/" + idioma + "/info.txt");
            Console.Clear();
            CambiarColor("COLOR", ConsoleColor.Yellow);
            Console.WriteLine(informacio.ReadLine());
            CambiarColor("COLOR", ConsoleColor.White);
            Console.WriteLine(informacio.ReadLine());
            Console.WriteLine(informacio.ReadLine());
            Console.WriteLine(informacio.ReadLine());
            CambiarColor("FONS", ConsoleColor.Green);
            Console.Write(informacio.ReadLine());
            CambiarColor("FONS", ConsoleColor.Black);
            Console.WriteLine(informacio.ReadLine());
            Console.WriteLine(informacio.ReadLine());
            CambiarColor("FONS", ConsoleColor.Yellow);
            CambiarColor("COLOR", ConsoleColor.Black);
            Console.Write(informacio.ReadLine());
            CambiarColor("COLOR", ConsoleColor.White);
            CambiarColor("FONS", ConsoleColor.Black);
            Console.WriteLine(informacio.ReadLine());
            Console.WriteLine(informacio.ReadLine());
            CambiarColor("FONS", ConsoleColor.Gray);
            CambiarColor("COLOR", ConsoleColor.Black);
            Console.WriteLine(informacio.ReadLine());
            CambiarColor("COLOR", ConsoleColor.White);
            CambiarColor("FONS", ConsoleColor.Black);
            Console.WriteLine(informacio.ReadLine());
            Console.WriteLine(informacio.ReadLine());
            Console.ReadKey();
            Console.Clear();
            informacio.Close();
        }
        /// <summary>
        /// Funcio per imprimir per pantalla imatges ASCII.
        /// </summary>
        /// <param name="path">Ubicacio del fitxer</param>
        /// <param name="nomFitxer">nom del fitxer amb la seva extensió</param>
        void PrintImage(string path, string nomFitxer)
        {
            StreamReader sr = File.OpenText(path + nomFitxer);
            Console.WriteLine(sr.ReadToEnd());
            sr.Close();
        }

        /// <summary>
        /// Funcio per cambiar de color per consola
        /// </summary>
        /// <param name="tipus">Si s'introdueix "FONS" cambiarà el BackgroundColor mentre si es "COLOR" cambiarà el ForegroundColor.</param>
        /// <param name="color">S'Introdueix el color a escollir</param>
        /// <returns>Retorna la linea de codi per imprimir per pantalla</returns>
        public ConsoleColor CambiarColor(string tipus, ConsoleColor color)
        {
            if (tipus.ToUpper() == "FONS")
            {
                return Console.BackgroundColor = color;
            }
            else if (tipus.ToUpper() == "COLOR")
            {
                return Console.ForegroundColor = color;
            }
            else
            {
                return Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
