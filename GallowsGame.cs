using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame
{
    class GallowsGame
    {
        private int userAttempt = 0;
        public void GuessWord(GallowsLogic gallowsLogic)
        {
            gallowsLogic.GuessWord();
            Console.WriteLine("Hello! I guessed the word. Let's try to guess it\n");
        }
        public void Play(GallowsLogic gallowsLogic)
        {
            while (userAttempt <= gallowsLogic.triesAmount && userAttempt <= gallowsLogic.maxNumberOfGuess)
            {
                if (userAttempt == gallowsLogic.triesAmount || userAttempt == gallowsLogic.maxNumberOfGuess)
                {
                    Console.WriteLine("You have last attemp to guess the word");
                }

                Console.WriteLine("Write the letter");
                char letter = Program.ReadChar();
                Console.WriteLine();

                if (gallowsLogic.Word.Contains(letter))
                {
                    Console.WriteLine(gallowsLogic.SetGuessStatus(letter)
                        ? "You guessed correctly!"
                        : "You already guessed that letter");
                }

                else
                {
                    Console.WriteLine($"You guessed wrongly! You have {gallowsLogic.maxNumberOfGuess - userAttempt} tries left\n");
                    userAttempt++;
                }
                if (gallowsLogic.IsOver())
                {
                    Console.WriteLine($"You won! The guessing word was {gallowsLogic.Word}.");
                    break;
                }

                if (userAttempt == gallowsLogic.maxNumberOfGuess || userAttempt == gallowsLogic.triesAmount)
                {
                    Console.WriteLine($"You lost! The guessing word was {gallowsLogic.Word}.");
                }

                gallowsLogic.Display();
            }
        }
    }
}
