﻿using System;
using System.Net;
using System.IO;
using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Threading;

namespace FortniteTournamentBot
{
    public class Program
    {
        public static void Main(string[] args)
        => new Program().startAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        private CommandHandler _handler;

        public async Task startAsync()
        {

            _client = new DiscordSocketClient();

            await _client.LoginAsync(TokenType.Bot, "NDY2Mjg1ODMwOTM2NDYxMzEy.Dj0UcA.bbhRKhvCMLFeyxJb7GFaZNPzTG8");

            await _client.StartAsync();

            _handler = new CommandHandler(_client);

            await Task.Delay(-1);
        }
        static string ExtractString(string s, string tag, string endtag)
        {
            // You should check for errors in real-world code, omitted for brevity
            var startTag = "<" + tag + ">";
            int startIndex = s.IndexOf(startTag) + startTag.Length;
            int endIndex = s.IndexOf("</" + endtag + ">", startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }
        static string ExtractScore(string s, string start, string end)
        {
            var startvar = start;
            int startIndex = s.IndexOf(startvar) + startvar.Length;
            int endIndex = s.IndexOf(end, startIndex);
            return s.Substring(startIndex, endIndex - startIndex);
        }
    }
}