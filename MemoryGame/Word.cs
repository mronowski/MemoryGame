using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    class Word
    {
        public string? TheWord { get; set; }
        public int Id { get; set; }

        public Word(string theWord, int ID) 
        {
            TheWord = theWord;
            Id = ID;
        }
    }
}
