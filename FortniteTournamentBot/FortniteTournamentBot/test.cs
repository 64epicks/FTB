using System;
using System.Net;
using System.IO;


namespace FortniteTournamentBot
{
    class MainClass
    {
		static string html;
        public static void Main(string[] args)
        {
			string url = "https://api.fortnitetracker.com/v1/profile/pc/AlastairPx86";
            
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Headers.Add("TRN-Api-Key: cc30fad7-10b6-4646-bf18-c9bc535268cf");
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

			//string rating = ExtractString(html, @"span class=""trn-vertstat__value""", "span");

            Console.WriteLine(html);
        }
		static string ExtractString(string s, string tag, string endtag)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = "<" + tag + ">";
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf("</" + endtag + ">", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }
		static string ExtractScore(string s, string start, string end){
			var startvar = start;
			int startIndex = s.IndexOf(startvar) + startvar.Length;
			int endIndex = s.IndexOf(end, startIndex);
			return s.Substring(startIndex, endIndex - startIndex);
    }
}