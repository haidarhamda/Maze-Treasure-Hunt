using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_2
{
    [Serializable]
    public class NoTreasureException : Exception
    {
        public NoTreasureException() : base("No treasure!") { }
    }

    [Serializable]
    public class StartingPointExceededException : Exception
    {
        public StartingPointExceededException() : base("starting point exceeded") { }
    }

    [Serializable]
    public class NoStartingPointException : Exception
    {
        public NoStartingPointException() : base("No starting point!") { }
    }

    [Serializable]
    public class CharacterNotRecognizedException : Exception
    {
        public CharacterNotRecognizedException() : base("Character not recognized!") { }
    }
}
