using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using SharpDB;
using System.Linq;

public class TournamentHandler : ModuleBase
{
    static DB db = new DB(Environment.CurrentDirectory);
    public static void New(string id, string timeTo)
    {
        string[] time = timeTo.Split(';');
        if (!db.DatabaseExists("Tournaments")) db.CreateDatabase("Tournaments");
        db.EnterDatabase("Tournaments");
        if (!db.TableExists("Tournaments", "timeLeft")) db.CreateTable("timeLeft", "Id;Time");
        if (!db.TableExists("Tournaments", "timeStart")) db.CreateTable("timeStart", "Id;Time");
        if (db.TableExists("Tournaments", id)) throw new Exception();
        db.CreateTable(id, "Id;Name;Platform;ScoreWhenJoin;Score");
        db.Insert("timeStart", id + ";" + time[0]);
        db.Insert("timeLeft", id + ";" + time[1]);

    }

}