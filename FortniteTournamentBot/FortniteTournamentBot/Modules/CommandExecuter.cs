using System;
using Discord.Commands;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace FortniteTournamentBot.Modules
{
	public class CommandExecuter : ModuleBase<SocketCommandContext>
    {
		List<string> admin = new List<string>{};
        [Command("init")]
		public async Task init(){
			admin.Add("284686457744916490");
			TournamentHandler.init();
			await Context.Channel.SendMessageAsync("Bot fully started");
		}
		[Command("test")]
		public async Task test(){
			await Context.Channel.SendMessageAsync("Tournament bot working");
		}
        [Command("new")]
		public async Task newTour(){
			if (admin.Contains(Context.Message.Author.Id.ToString()))
			{ }
				TournamentHandler.newGame();

				await Context.Channel.SendMessageAsync("Tournament started");
			


		}
		[Command("setstart")]
		public async Task set(int content)
		{


			if (!TournamentHandler.setStart(content))
			{
				await Context.Channel.SendMessageAsync("Start time already set, please start a new with !new");

			}
			else
			{
				await Context.Channel.SendMessageAsync("Start time = " + content);
			}

		}
    }
}
