using Olio_ohjelmointi_projekti.Kauppa;
using System.Net.Http.Headers;

namespace Olio_ohjelmointi_projekti.Peli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();

            Console.ReadKey();
        }
    }
}
