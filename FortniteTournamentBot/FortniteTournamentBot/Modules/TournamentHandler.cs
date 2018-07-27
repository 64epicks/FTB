using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class TournamentHandler : ModuleBase
{
	static string datapath = "game.txt";
	static bool initbo;
	static List<string[]> full = new List<string[]> { };
	static List<string> stringfull = new List<string> { };

	public static void init()
	{
		full.Add(File.ReadAllLines(datapath));
		Console.WriteLine(full.Count);
	}
	public static void newGame()
	{
		File.WriteAllLines(datapath, new List<string> { "" });
		List<string> lines = new List<string> { };
		lines.Add("<created>" + DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString() + "</created>");
		File.WriteAllLines(datapath, lines);
	}
	public static bool setStart(int time)
	{
		full.Add(new string[] { "<start>" + time + "</start>" });
		Console.WriteLine(full.Count);
		if (full[1] == new string[]{"<start>" + time + "</start>"})
		{
			//full.Add(new string[] { "<start>" + time + "</start>" });
            File.WriteAllLines(datapath, (IEnumerable<string>)full);
            return true;
		}
		else
		{
			return false;
		}
	}
	public static bool setEnd(string time)
	{
		if (full.Count <= 0){
			return false;
		}
		else{
			full.Add(new string[] { "<end>" + Int32.Parse(time).ToString() + "</end>" });
			File.WriteAllLines(datapath, (IEnumerable<string>)full);
			return true;
		}
	}
}
