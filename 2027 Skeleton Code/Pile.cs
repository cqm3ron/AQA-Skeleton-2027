using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2027_Skeleton_Code
{
    class Pile
    {
        protected List<Tile> Tiles;
        protected int Max;
        protected int Bonus;

        public Pile(int M, int B)
        {
            Tiles = new List<Tile>();
            Max = M;
            Bonus = B;
        }

        public virtual void Add(Tile T)
        {
            if (Tiles.Count < Max)
            {
                Tiles.Insert(0, T);
            }
        }

        public virtual char GetSymbolOfTopTile()
        {
            return Tiles[0].GetSymbol();
        }

        public virtual Tile Remove()
        {
            Tile Temp = Tiles[0];
            Tiles.RemoveAt(0);
            return Temp;
        }

        public virtual bool Empty()
        {
            if (Tiles.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual int GetNumberOfTiles()
        {
            return Tiles.Count;
        }
    }
}
