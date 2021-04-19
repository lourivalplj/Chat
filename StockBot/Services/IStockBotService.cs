using UI.Models;

namespace StockBot.Services
{
    public interface IStockBotService
    {
        Stock GetStock(string stock_code);
    }
}
