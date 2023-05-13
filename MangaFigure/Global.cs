using System.Security.Claims;

namespace MangaFigure
{
    public class Global
    {
        public static Global _instance = new Global();
        private Global() { }

        public static Global GetInstance()
        {
            return _instance;
        }
    }
}
