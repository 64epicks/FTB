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
        public async Task newComp()
        {
            await Context.Channel.SendMessageAsync("Creating tournament for channel " + Context.Channel.Id);
            try
            {
                TournamentHandler.New(Context.Channel.Id.ToString());
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("Tournament already going on!");
            }
        }
        [Command("join")]
		public async Task join(string input){
			int id; 
			string[] inputArr = input.Split(',');
			if (inputArr.Length != 2) await Context.Channel.SendMessageAsync("Please input both username and platform (\"!join YOURUSERNAME,YOURPLATFORM\"");
			else
			{

				id = TournamentHandler.Join(inputArr, Context.Channel.Id.ToString());

				switch(id){
					case -1:{
							await Context.Channel.SendMessageAsync("Tournament does not exist!");
							return;
						};
					case -2:{
							await Context.Channel.SendMessageAsync("You have already joined!");
							return;
						}
					case -3:{
							await Context.Channel.SendMessageAsync("Account does not exist!");
							return;
						}
				}

				await Context.Channel.SendMessageAsync("You been added! Your id: " + id);
			}
		}
        // TODO: Understand why program freezes after one command


    }
}