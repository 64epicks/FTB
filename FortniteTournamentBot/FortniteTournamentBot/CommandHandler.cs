using System;
using Discord.WebSocket;
using Discord;
using Discord.Commands;
using System.Reflection;
using System.Threading.Tasks;

namespace FortniteTournamentBot
{
    public class CommandHandler
	{
		public static string[] WaitForTime = { "", "" };

		private DiscordSocketClient _client;

		private CommandService _service;

		public CommandHandler(DiscordSocketClient client){
			
			_client = client;

			_service = new CommandService();

			_service.AddModulesAsync(Assembly.GetEntryAssembly());

			_client.MessageReceived += handleCommandAsync;
        }

		private async Task handleCommandAsync(SocketMessage s){
			var msg = s as SocketUserMessage;
			if (msg == null) return;

			var context = new SocketCommandContext(_client, msg);

			int argPos = 0;

			if (msg.HasCharPrefix('!', ref argPos) || msg.HasCharPrefix('.', ref argPos))
			{
				var result = await _service.ExecuteAsync(context, argPos);

				if (!result.IsSuccess)
				{
					await context.Channel.SendMessageAsync(result.ErrorReason);
				}
			}
			Console.WriteLine(DateTime.Now + " " + context.Message.Author.Username + "#" + context.Message.Author.Id + "@" + context.Channel.Name + "#" + context.Channel.Id + ": \n" + context.Message.Content);
		}
    }
}
