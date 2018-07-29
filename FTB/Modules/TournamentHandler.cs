using System;
using Discord.Commands;
using Newtonsoft.Json;
using System.IO;
using SharpDB;
using System.Linq;
using System.Threading;
using System.Net;

public class TournamentHandler : ModuleBase
{
    static DB db = new DB(Environment.CurrentDirectory);
    public static void New(string id)
	{
        if (!db.DatabaseExists("Tournaments")) db.CreateDatabase("Tournaments");
        db.EnterDatabase("Tournaments");
        //if (!db.TableExists("Tournaments", "timeLeft")) db.CreateTable("timeLeft", "Id;Time");
        if (db.TableExists("Tournaments", id)) throw new Exception();
        db.CreateTable(id, "Id;Name;Platform;ScoreWhenJoin;Score");
        //db.Insert("timeLeft", id + ";" + timeTo);

    } 
	public static int Join(string[] input, string id){
		db.EnterDatabase("Tournaments");
		if (!db.TableExists("Tournaments", id)) return -1;
		if (db.Get("Id", id, "Name=" + input[0] + ";Platform=" + input[1]).Length > 0) return -2;
		if (getScore(input[0], input[1]) == -1) return -3;

		db.Insert(id, (db.TableLength("Tournaments", id) + 1).ToString() + ";" + input[0] + ";" + input[1] + ";;");
		return db.TableLength("Tournaments", id);


	}
	public static int getScore(string name, string platform){
		string html = string.Empty;
		string url = @"https://api.fortnitetracker.com/v1/profile/" + platform + "/" + name;

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;
		request.Headers.Add("TRN-Api-Key: cc30fad7-10b6-4646-bf18-c9bc535268cf");

        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream stream = response.GetResponseStream())
        using (StreamReader reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }

		dynamic json = JsonConvert.DeserializeObject(html);
		if (json.error == "Player Not Found") return -1;
		return json.stats.p2.score.valueInt;
       
	}

}