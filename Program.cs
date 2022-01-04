using System;
namespace GallowsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the maximum amount of tries you want to guess the word");
            int triesAmount = int.Parse(Console.ReadLine());

            GallowsLogic gallowsLogic = new (triesAmount);
            GallowsGame game = new();
            game.GuessWord(gallowsLogic);
            game.Play(gallowsLogic);
            Console.ReadLine();
        }
        public static char ReadChar()
        {
            char value;
            try
            {
                value = char.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You has not written a correct symbol");
                return ReadChar();
            }
            return value;
        }
    }
}
