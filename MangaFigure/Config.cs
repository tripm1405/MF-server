namespace MangaFigure
{
    public static class Config
    {
        public static string OUT = "https://localhost:7114";
        public static string OUT_PRODUCTS = OUT + "/Uploads/Products/";
        public static string OUT_LOGOS = OUT + "/Uploads/Logos/";
        public static string OUT_SLIDESHOWS = OUT + "/Uploads/SlideShows/";
        public static string IN = Directory.GetCurrentDirectory();
        public static string IN_PRODUCTS = IN + "/wwwroot/Uploads/Products/";
        public static string IN_LOGOS = IN + "/wwwroot/Uploads/Logos/";
        public static string IN_SLIDESHOWS = IN + "/wwwroot/Uploads/SlideShows/";
    }
}
