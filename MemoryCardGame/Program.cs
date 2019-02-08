namespace MemoryCardGame
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            MemoryGame game = new MemoryGame();
            game.Start();
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }
    }
}
