namespace _2027_Skeleton_Code
{
    //Skeleton Program code for the AQA A Level Paper 1 Summer 2027 examination
    //this code should be used in conjunction with the Preliminary Material
    //written by the AQA Programmer Team
    //developed in the Visual Studio Community Edition programming environment

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<Pile> Board = new List<Pile>();
            List<Player> Players = new List<Player>();
            List<Tile> Discard = new List<Tile>();
            int TurnsSinceMatch = 0;
            int WhoseTurn = 0;
            int MaxScore = 10;
            const string FileExtension = ".txt";
            Console.Write("Enter filename to load or just press Enter to play the default game: ");
            string FileName = Console.ReadLine() + FileExtension;
            bool UseDataFromFile = false;
            if (FileName != FileExtension)
            {
                if (LoadGame(FileName, Board, Players, Discard, ref MaxScore, ref WhoseTurn, ref TurnsSinceMatch) == true)
                {
                    UseDataFromFile = true;
                }
                else
                {
                    Console.WriteLine("Setting up default game");
                    UseDataFromFile = false;
                }
            }
            if (UseDataFromFile == false)
            {
                Players.Add(new Player("Player 1", 0));
                Players.Add(new Player("Player 2", 0));
                for (int Count = 1; Count <= 36; Count++)
                {
                    Pile P = new Pile(3, 0);
                    P.Add(new Tile('A', 1));
                    P.Add(new Tile('B', 2));
                    P.Add(new Tile('A', 1));
                    Board.Add(P);
                }
            }
            Game ThisGame = new Game(Board, Players, Discard, WhoseTurn, MaxScore, TurnsSinceMatch);
            ThisGame.PlayGame();
            Console.ReadLine();
        }

        static bool LoadGame(string FileName, List<Pile> Board, List<Player> Players, List<Tile> Discard,
            ref int MaxScore, ref int WhoseTurn, ref int TurnsSinceMatch)
        {
            try
            {
                using (StreamReader MyStream = new StreamReader(FileName))
                {
                    List<string> Items;
                    string LineFromFile;
                    int BoardSize, NoOfPlayers;
                    LineFromFile = MyStream.ReadLine();
                    BoardSize = Convert.ToInt32(LineFromFile);
                    for (int i = 1; i <= BoardSize; i++)
                    {
                        LineFromFile = MyStream.ReadLine();
                        Items = LineFromFile.Split(',').ToList();
                        int PileSize = Items.Count / 2;
                        Pile P = new Pile(PileSize, Convert.ToInt32(Items[0]));
                        for (int TileNo = Items.Count - 2; TileNo >= 0; TileNo -= 2)
                        {
                            P.Add(new Tile(Items[TileNo][0], Convert.ToInt32(Items[TileNo + 1])));
                        }
                        Board.Add(P);
                    }
                    LineFromFile = MyStream.ReadLine();
                    NoOfPlayers = Convert.ToInt32(LineFromFile);
                    for (int i = 1; i <= NoOfPlayers; i++)
                    {
                        LineFromFile = MyStream.ReadLine();
                        Items = LineFromFile.Split(',').ToList();
                        Players.Add(new Player(Items[0], Convert.ToInt32(Items[1])));
                    }
                    LineFromFile = MyStream.ReadLine();
                    Items = LineFromFile.Split(',').ToList();
                    for (int i = 0; i < Items.Count - 1; i += 2)
                    {
                        Discard.Add(new Tile(Items[i][0], Convert.ToInt32(Items[i + 1])));
                    }
                    LineFromFile = MyStream.ReadLine();
                    MaxScore = Convert.ToInt32(LineFromFile);
                    LineFromFile = MyStream.ReadLine();
                    WhoseTurn = Convert.ToInt32(LineFromFile);
                    LineFromFile = MyStream.ReadLine();
                    TurnsSinceMatch = Convert.ToInt32(LineFromFile);
                }
            }
            catch
            {
                Console.WriteLine("File not loaded");
                return false;
            }
            return true;
        }
    }
}
