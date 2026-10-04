using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2027_Skeleton_Code
{
    class Tile
    {
        protected char Symbol;
        protected int Points;

        public Tile(char S, int P)
        {
            Symbol = S;
            Points = P;
        }

        public virtual int GetPoints()
        {
            return Points;
        }

        public virtual char GetSymbol()
        {
            return Symbol;
        }
    }
}
