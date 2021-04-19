using UI.Entities;

namespace UI.Services
{
    public interface IStockBotService
    {
        BotResponse BotDetection(string message);
    }
}
