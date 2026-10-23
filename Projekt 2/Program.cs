using System.Diagnostics;
Console.CursorVisible = false;
Spil spil = new Spil();
spil.figur = new Figur();
spil.forhindringer = new Forhindringer();
spil.leaderboard = new Leaderboard();
spil.startMenu();

class Spil
{
    public Figur figur;
    public Forhindringer forhindringer;
    public Leaderboard leaderboard;
    bool spilKører = true;
    public void startMenu()
    {
        Console.WriteLine("Du har nu 2 valgmuligheder, vælg:");
        Console.WriteLine("1. For at starte nyt spil");
        Console.WriteLine("2. For at se leaderboard");
        string svar = Console.ReadKey(true).KeyChar.ToString();
        if (svar == "1")
        {
            Console.Clear();
            nytSpil();
        }
        if (svar == "2")
        {
            Console.Clear();
            Console.WriteLine("WIP");
        }
    }

    public void nytSpil()
    {
        int i = 0;
        int f = 0;
        int hop = 0;
        int gammely = figur.y;
        int hopHøjde = 0;
        int tæller = 0;
        figur.opretFigur();
        forhindringer.opretForhindring();
        opretBane();
        while (true)
        {
            Random rand = new Random();
            if (tæller == 0)
            {
                f = rand.Next(0, forhindringer.ForhindringsList.Count);
                Console.SetCursorPosition(forhindringer.ForhindringsList[f].x, forhindringer.ForhindringsList[f].y);
                Console.WriteLine(forhindringer.ForhindringsList[f].krop);
                tæller++;
            }

            //opretTimer();

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && hopHøjde == 0)
                {
                    hop = 9;
                }
            }
            if (hop > 0)
            {
                Console.SetCursorPosition(figur.x, gammely + 1);
                Console.Write("   ");
                Console.SetCursorPosition(figur.x, gammely + 2);
                Console.Write("   ");


                hop--;
                hopHøjde = 2;
                Console.SetCursorPosition(figur.x, figur.y - 2);
                Console.Write(" o");
                Console.SetCursorPosition(figur.x, figur.y - 1);
                Console.Write("/|\\");
                Console.SetCursorPosition(figur.x, figur.y);
                Console.Write("/ \\");

            }
            else
            {
                hopHøjde = 0;
                Console.SetCursorPosition(figur.x, figur.y - 2);
                Console.Write("   ");
                Console.SetCursorPosition(figur.x, figur.y - 1);
                Console.Write("   ");
                Console.SetCursorPosition(figur.x, figur.y);
                Console.Write("   ");
                figur.opretFigur();
            }

            //forhindringer kommer tilbage efter at have ramt kanten af CMD
            if (forhindringer.ForhindringsList[0].x >= Console.WindowWidth - 6)
            {
                Console.SetCursorPosition(forhindringer.ForhindringsList[0].x, forhindringer.ForhindringsList[0].y);
                Console.Write("      ");
                forhindringer.ForhindringsList[0].x = 0;
                tæller--;

            }

            if (forhindringer.ForhindringsList[1].x < 3)
            {
                Console.SetCursorPosition(forhindringer.ForhindringsList[1].x, forhindringer.ForhindringsList[1].y);
                Console.Write("      ");
                forhindringer.ForhindringsList[1].x = 110;
                tæller--;

            }

            //forhindringer bevæger sig
            if (i == 0)
            {
                while (i < forhindringer.ForhindringsList.Count)
                {
                    if (i == 0 && f == 0)
                    {
                        Console.SetCursorPosition(forhindringer.ForhindringsList[i].x, forhindringer.ForhindringsList[i].y);
                        Console.Write("      ");
                        forhindringer.ForhindringsList[i].x++;
                        Console.SetCursorPosition(forhindringer.ForhindringsList[i].x, forhindringer.ForhindringsList[i].y);
                        Console.Write(forhindringer.ForhindringsList[i].krop);
                    }
                    if (i == 1 && f == 1)
                    {
                        Console.SetCursorPosition(forhindringer.ForhindringsList[i].x, forhindringer.ForhindringsList[i].y);
                        Console.Write("      ");
                        forhindringer.ForhindringsList[i].x--;
                        Console.SetCursorPosition(forhindringer.ForhindringsList[i].x, forhindringer.ForhindringsList[i].y);
                        Console.Write(forhindringer.ForhindringsList[i].krop);
                    }
                    i++;
                }
                i = 0;
            }

            //forhindringer kommer tilbage efter at have ramt kanten af CMD
            if (forhindringer.ForhindringsList[0].x >= Console.WindowWidth - 6)
            {
                Console.SetCursorPosition(forhindringer.ForhindringsList[0].x, forhindringer.ForhindringsList[0].y);
                Console.Write("      ");
                forhindringer.ForhindringsList[0].x = 0;
                tæller--;

            }

            if (forhindringer.ForhindringsList[1].x < 3)
            {
                Console.SetCursorPosition(forhindringer.ForhindringsList[1].x, forhindringer.ForhindringsList[1].y);
                Console.Write("      ");
                forhindringer.ForhindringsList[1].x = 110;
                tæller--;

            }

            if (figur.x == forhindringer.ForhindringsList[0].x)
            {
                if (hopHøjde == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 10);
                    Console.WriteLine("Du tabte!");
                    break;
                }
            }
            if (figur.x == forhindringer.ForhindringsList[1].x)
            {
                if (hopHøjde == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 10);
                    Console.WriteLine("Du tabte!");
                    break;
                }
                if (figur.x == forhindringer.ForhindringsList[f].x && hopHøjde == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 10);
                    Console.WriteLine("Du tabte, øv bøv!");
                    break;
                }
            }
            Thread.Sleep(100);
        }
    }
    public void loadLeaderboard()
    {

    }

    public void opretBane()
    {
        int i = 0;
        while (i < Console.WindowWidth)
        {
            Console.SetCursorPosition(i, 8);
            Console.WriteLine("~");
            i++;
        }
    }
    public void opretTimer() // Virker ikke lige pt.
    {
        Stopwatch timer = new Stopwatch();
        int tid = 0;
        while (true)
        {
            if (timer.ElapsedMilliseconds >= 1000)
            {
                Console.SetCursorPosition(Console.WindowWidth - 10, 1);
                Console.Write("Tid: " + tid);
                tid++;
                timer.Restart();
            }
        }
    }
}

class Figur
{
    public string hoved;
    public string krop;
    public string ben;
    public int x = 55;
    public int y = 5;

    public void opretFigur()
    {
        Figur mand = new Figur();
        mand.hoved = " o";
        mand.krop = "/|\\";
        mand.ben = "/ \\";

        Console.SetCursorPosition(x, y);
        Console.Write(mand.hoved);
        Console.SetCursorPosition(x, y + 1);
        Console.Write(mand.krop);
        Console.SetCursorPosition(x, y + 2);
        Console.Write(mand.ben);
    }
}

class Forhindringer
{
    public List<Forhindring> ForhindringsList = new List<Forhindring>();
    public void opretForhindring()
    {
        skabForhindring("hundV", 0, 7, "-|¯¯|ö");
        skabForhindring("hundH", 110, 7, "ö|¯¯|-");
    }
    public void skabForhindring(string navn, int x, int y, string krop)
    {
        Forhindring forhindring = new Forhindring();
        forhindring.navn = navn;
        forhindring.x = x;
        forhindring.y = y;
        forhindring.krop = krop;
        ForhindringsList.Add(forhindring);
    }
}

class Forhindring
{
    public string navn;
    public int x;
    public int y;
    public string krop;
}

class Leaderboard // Kan ikke bruges, da vores timer ikke virker, som er grundsten for vores points/score system
{
    Leaderboard[] TopTi = new Leaderboard[10];
    TopTi adgang;
    public void opretLeaderboard()
    {
        int i = 0;
        while (i < TopTi.Length)
        {
            TopTi[i] = new Leaderboard();
            i++;
        }
    }
}

class TopTi // Samme som leaderboard
{
    public int placering;
    public string navn;
    public int score;
}