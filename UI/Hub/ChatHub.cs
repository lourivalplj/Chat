using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using UI.Models;
using UI.Services;

namespace UI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IStockBotService StockBotService;

        public ChatHub(IStockBotService _stockBotService)
        {
            StockBotService = _stockBotService;
        }

        
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
            var botResponse = StockBotService.BotDetection(message.Text);
            if (botResponse.Detected)
                if (botResponse.IsSuccessful)
                    await Clients.All.SendAsync("receiveMessage", StockBotMessage($"{botResponse.Symbol} quote is {botResponse.Close} per share"));
                else
                    await Clients.All.SendAsync("receiveMessage", StockBotMessage($"Houston, we have a problem. { botResponse.ErrorMessage }"));
        }

        
        internal Message StockBotMessage(string text)
        {
            return new Message
            {
                UserName = "StockBot",
                Text = text,
                When = DateTime.Now
            };
        }

    }
}
