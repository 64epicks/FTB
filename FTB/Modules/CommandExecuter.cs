using System;
using Discord;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Threading;

namespace FortniteTournamentBot.Modules
{
    public class CommandExecuter : ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task test()
        {
            await Context.Channel.SendMessageAsync("Tournament bot working");
            Console.WriteLine("he");

        }
        [Command("new")]
        public async Task newComp(string timeTo)
        {
            await Context.Channel.SendMessageAsync("Creating tournament for channel " + Context.Channel.Id);
            try
            {
                TournamentHandler.New(Context.Channel.Id.ToString(), timeTo);
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("Tournament already going on!");
            }
            CommandHandler.WaitForTime = new string[] { Context.Message.Author.Id.ToString(), Context.Channel.Id.ToString() };
            await Context.Channel.SendMessageAsync("Please enter end time");
        }
        [Command("newnew")]
        public async Task newnew()
        {

        }
        // TODO: Understand why program freezes after one command


    }
}