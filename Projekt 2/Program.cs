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
        int hop = 0;
        int gammely = figur.y;
        int hopHøjde = 0;
        figur.opretFigur();
        forhindringer.opretForhindring();
        opretBane();
        while (true)
        {

            //opretTimer();

            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow && hop == 0)
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
    public void opretTimer()
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
        int i = 0;
        while (i < ForhindringsList.Count)
        {
            Console.SetCursorPosition(ForhindringsList[i].x, ForhindringsList[i].y);
            Console.WriteLine(ForhindringsList[i].krop);
            i++;
        }
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

class Leaderboard
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

class TopTi
{
    public int placering;
    public string navn;
    public int score;
}

//test