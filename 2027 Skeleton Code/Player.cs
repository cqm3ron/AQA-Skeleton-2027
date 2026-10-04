using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2027_Skeleton_Code
{
    class Player
    {
        protected string Name;
        protected int Score;

        public Player(string N, int S)
        {
            Name = N;
            Score = S;
        }

        public virtual int GetScore()
        {
            return Score;
        }

        public virtual string GetName()
        {
            return Name;
        }

        public virtual void ChangeScore(int Change)
        {
            Score += Change;
        }
    }
}
