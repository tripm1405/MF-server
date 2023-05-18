using System.Linq;
using System.Security.Claims;

namespace MangaFigure
{
    public static class Config
    {
        public static string OUT = "https://localhost:7114";
        public static string OUT_PRODUCTS = OUT + "/Uploads/Products/";
        public static string OUT_LOGOS = OUT + "/Uploads/Logos/";
        public static string OUT_SLIDESHOWS = OUT + "/Uploads/SlideShows/";
        public static string OUT_ANNOUNCES = OUT + "/Uploads/Announces/";
        public static string IN = Directory.GetCurrentDirectory();
        public static string IN_PRODUCTS = IN + "/wwwroot/Uploads/Products/";
        public static string IN_LOGOS = IN + "/wwwroot/Uploads/Logos/";
        public static string IN_SLIDESHOWS = IN + "/wwwroot/Uploads/SlideShows/";
        public static string IN_ANNOUNCES = IN + "/wwwroot/Uploads/Announces/";

        public static string CreateMetaWithHash(string meta = "")
        {
            List<string> strs = new List<string>();

            if (meta != "")
            {
                strs.Add(RemoveUnicode(meta.ToLower()));
            }
    
            strs.Add(new Random().Next(1000, 10000).ToString());

            return string.Join("-", strs);
        }
        
        public static string RemoveUnicode(string text)  
        {  
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",  
                "đ",  
                "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",  
                "í","ì","ỉ","ĩ","ị",  
                "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",  
                "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",  
                "ý","ỳ","ỷ","ỹ","ỵ",};  
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",  
                "d",  
                "e","e","e","e","e","e","e","e","e","e","e",  
                "i","i","i","i","i",  
                "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",  
                "u","u","u","u","u","u","u","u","u","u","u",  
                "y","y","y","y","y",};  
            for (int i = 0; i < arr1.Length; i++)  
            {  
                text = text.Replace(arr1[i], arr2[i]);  
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());  
            }  
            return text;  
        }  
    }

    public class User
    {
        public int? Id { get; set; }
        public int? Role { get; set; }
    }
}
