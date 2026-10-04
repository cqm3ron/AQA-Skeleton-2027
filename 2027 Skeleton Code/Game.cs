namespace _2027_Skeleton_Code
{
    class Game
    {
        private List<Pile> Board;
        private List<Player> Players;
        private List<Tile> Discard;
        private int WhoseTurn;
        private int MaxScore;
        private int TurnsSinceMatch;
        private bool GameOver;
        private int GridSize;

        public Game(List<Pile> B, List<Player> P, List<Tile> D, int WT, int MS, int TSM)
        {
            Board = B;
            Players = P;
            Discard = D;
            WhoseTurn = WT;
            MaxScore = MS;
            TurnsSinceMatch = TSM;
            GameOver = false;
            GridSize = (int)Math.Sqrt(Board.Count);
        }

        public void PlayGame()
        {
            while (GameOver == false)
            {
                string Choice = "";
                while (Choice != "T")
                {
                    DisplayMenu();
                    Choice = GetChoice();
                    if (Choice == "B")
                    {
                        DisplayBoard();
                    }
                    else if (Choice == "D")
                    {
                        DisplayDiscard();
                    }
                    else if (Choice == "S")
                    {
                        DisplayScores();
                    }
                }
                int Pile1 = ChoosePile();
                int Pile2;
                do
                {
                    Pile2 = ChoosePile();
                } while (Pile1 == Pile2);
                TurnsSinceMatch++;
                if (Board[Pile1].Empty() == false && Board[Pile2].Empty() == false)
                {
                    if (Board[Pile1].GetSymbolOfTopTile() == Board[Pile2].GetSymbolOfTopTile())
                    {
                        TurnsSinceMatch = 0;
                        Tile Tile1 = Board[Pile1].Remove();
                        Tile Tile2 = Board[Pile2].Remove();
                        Discard.Add(Tile1);
                        Discard.Add(Tile2);
                        int ScoreIncrease = 0;
                        ScoreIncrease += Tile1.GetPoints() + Tile2.GetPoints();
                        Players[WhoseTurn].ChangeScore(ScoreIncrease);
                        Console.WriteLine($"{Players[WhoseTurn].GetName()}, you had two matching {Tile1.GetSymbol()} tiles; your score has increased by {ScoreIncrease}");
                    }
                    else
                    {
                        Console.WriteLine("You did not find a matching pair.");
                        Console.WriteLine($"The first pile you chose had a {Board[Pile1].GetSymbolOfTopTile()}");
                        Console.WriteLine($"The second pile you chose had a {Board[Pile2].GetSymbolOfTopTile()}");
                    }
                }
                else
                {
                    Console.WriteLine("You chose an empty pile");
                }

                Console.WriteLine();
                UpdateWhoseTurn();
                GameOver = MaxScoreReached() || NoMoreTilesLeft();
            }
            if (Players[0].GetScore() > Players[1].GetScore())
            {
                Console.WriteLine($"{Players[0].GetName()} has won!");
            }
            else if (Players[1].GetScore() > Players[0].GetScore())
            {
                Console.WriteLine($"{Players[1].GetName()} has won!");
            }
        }

        private void DisplayScores()
        {
            Console.WriteLine();
            foreach (Player P in Players)
            {
                Console.WriteLine($"{P.GetName()}: has a score of {P.GetScore()}");
            }
            Console.WriteLine();
        }

        private void DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("MENU");
            Console.WriteLine("B. Display the board");
            Console.WriteLine("D. Display the discard");
            Console.WriteLine("T. Take turn");
            Console.WriteLine("S. Display scores");
            Console.WriteLine();
        }

        private string GetChoice()
        {
            string Choice = "";
            Console.Write($"{Players[WhoseTurn].GetName()}, enter your choice: ");
            Choice = Console.ReadLine();
            return Choice;
        }

        private void DisplayBoard()
        {
            for (int y = GridSize; y >= 1; y--)
            {
                Console.Write($"{y}|");
                for (int x = 1; x <= GridSize; x++)
                {
                    Console.Write(Board[GetIndex(x, y)].GetNumberOfTiles());
                }
                Console.WriteLine();
            }
            Console.Write("  ");
            for (int x = 1; x <= GridSize; x++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int x = 1; x <= GridSize; x++)
            {
                Console.Write(x);
            }
            Console.WriteLine();
        }

        private void DisplayDiscard()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Discard: ");
            if (Discard.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.Write(Discard[0].GetSymbol());
                int Count = 1;
                while (Count < Discard.Count)
                {
                    Console.Write($", {Discard[Count].GetSymbol()}");
                    Count++;
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private int ChoosePile()
        {
            int x = 0, y = 0;
            Console.Write("Enter x coordinate: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter y coordinate: ");
            y = Convert.ToInt32(Console.ReadLine());
            return GetIndex(x, y);
        }

        private int GetIndex(int x, int y)
        {
            return x - 1 + ((y - 1) * GridSize);
        }

        private void UpdateWhoseTurn()
        {
            WhoseTurn = (WhoseTurn + 1) % Players.Count;
        }

        private bool NoMoreTilesLeft()
        {
            foreach (Pile P in Board)
            {
                if (P.Empty() == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool MaxScoreReached()
        {
            foreach (Player P in Players)
            {
                if (P.GetScore() >= MaxScore)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
