using NUnit.Framework;
using System;

namespace WordleTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MostrarIntents()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            int intents = 1;
            Assert.IsTrue(app.MostrarIntents(idioma,intents) == 1);

        }

        [Test]
        public void MostrarIntentsLimit()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            int intents = 1;
            Assert.IsFalse(app.MostrarIntents(idioma, intents) == 10);
        }

        [Test]
        public void ComprovarParaulaTestWithNormalCharacters()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            Assert.IsTrue(app.ComprovarCaractersParaulaJugador("pacos",idioma) == true);

        }

        [Test]
        public void ComprovarParaulaTestWithSpecialCharacters()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            Assert.IsTrue(app.ComprovarCaractersParaulaJugador("ñacos",idioma) == false);

        }
        [Test]
        public void ImprimirIdiomes()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string[] idiomesFuncio = app.ImprimirIdiomes("../../../config.txt");
            string[] idiomes = { "ESPAÑOL", "es", "CATALA", "cat", "INGLES", "en"};
            Assert.AreEqual( idiomesFuncio, idiomes);
        }
        [Test]
        public void ImprimirIdiomesLimit()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string[] idiomesFuncio = app.ImprimirIdiomes("../../../config.txt");
            string[] idiomes = { "PORTUGUES", "ESPAÑOL", "SENEGALES", "ITALIANO", "INGLES", "CATALAN" };
            Assert.IsFalse(idiomesFuncio == idiomes);
        }
        [Test]
        public void SetIdiomaTest()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            string opcioIdioma = "Ingles";
            Assert.AreEqual(app.SetIdioma(ref idioma, opcioIdioma), "en");

        }
        [Test]
        public void SetIdiomaTestDefault()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            string idioma = "es";
            string opcioIdioma = "Italiano";
            Assert.AreEqual(app.SetIdioma(ref idioma, opcioIdioma),"cat");
        }
        [Test]
        public void MostrarParaulaTestSomeIncorrect()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            int contador = 0;
            Assert.IsTrue(app.MostrarParaula("pepep", "pepes",contador) == 4);
        }
        [Test]
        public void MostrarParaulaTestAllCorrect()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            int contador = 0;
            Assert.IsTrue(app.MostrarParaula("jugar", "jugar", contador) == 5);
        }
        [Test]
        public void MostrarParaulaTestIncorrect()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            int contador = 0;
            Assert.IsTrue(app.MostrarParaula("betis", "jamon", contador) == 0);
        }
        [Test]
        public void CambiarColorTestColor()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            Assert.AreEqual(app.CambiarColor("COLOR", ConsoleColor.Red), (Console.ForegroundColor = ConsoleColor.Red));
        }
        [Test]
        public void CambiarColorTestBackground()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            Assert.AreEqual(app.CambiarColor("FONS", ConsoleColor.Red), (Console.BackgroundColor = ConsoleColor.Red));
        }
        [Test]
        public void CambiarColorTestDefault()
        {
            Wordle.Wordle app = new Wordle.Wordle();
            Assert.AreEqual(app.CambiarColor("ColorFondo", ConsoleColor.Red), (Console.BackgroundColor = ConsoleColor.White));
        }
    }
}