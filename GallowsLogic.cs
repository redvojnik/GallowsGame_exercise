using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GallowsGame
{
    class GallowsLogic
    {
        private List<LetterStatus> LettersList;
        public string Word { get; set; }
        public readonly int triesAmount = 6;
        public int maxNumberOfGuess;

        public GallowsLogic(int triesAmount)
        {
            LettersList = new List<LetterStatus>();
            this.triesAmount = triesAmount;
        }

        //put word from File and randomise word's choise by App
        public void GuessWord()
        {
            string[] GallowDictionary = File.ReadAllLines("GallowDictionary.txt");

            Random random = new ();

            int wordIndex = random.Next(0, GallowDictionary.Length - 1);

            Word = GallowDictionary[wordIndex];
            maxNumberOfGuess = Word.Length;

            foreach (var letter in Word)
            {
                LettersList.Add(new LetterStatus(letter, false));
            }
        }
        public bool SetGuessStatus(char letter)
        {
            List<LetterStatus> tempLettersList = new();

            foreach (LetterStatus item in LettersList)
            {
                if (item.Letter == letter && item.HasBeenGuessed)
                {
                    return false;
                }
                tempLettersList.Add(item.Letter == letter 
                    ? new LetterStatus(letter, true) 
                    : item);
            }

            LettersList = tempLettersList;

            return true;
        }
        public void Display()
        {
            StringBuilder GallowsWord = new ();

            foreach (var item in LettersList)
            { // if(<> == true) => if(<>)
                GallowsWord.Append(!item.HasBeenGuessed ? '_' : item.Letter); // item.HasBeenGuessed ? item.Letter : '_'
            }

            Console.Write(GallowsWord.ToString()+"\n");
        }
        public bool IsOver()
        {
            return !LettersList.Any(letter => letter.HasBeenGuessed == false);
            // LettersList.All(letter => letter.HasBeenGuessed)
        }
    }
}

