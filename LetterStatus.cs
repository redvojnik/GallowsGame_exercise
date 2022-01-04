using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame
{
    class LetterStatus
    {
        public char Letter { get; set; }
        public bool HasBeenGuessed { get; set; }
        public LetterStatus(char letter, bool hasBeenGuessed)
        {
            this.Letter = letter;
            this.HasBeenGuessed = hasBeenGuessed;
        }
    }
}
