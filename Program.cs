using System;

namespace TRODS
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (Game1 game = new Game1()) // Pour s'assurer que tout le contenu sera lib�r� � la fin de l�xecution
            {
                game.Run();
            }
        }
    }
#endif
}

