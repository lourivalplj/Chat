using UI.Models;
using Microsoft.AspNetCore.Mvc;
using StockBot.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockBot.Controllers
{
    public class StockBotController : Controller
    {
        private IStockBotService StockBotService;
        public StockBotController(IStockBotService stockInfoDomain)
        {
            StockBotService = stockInfoDomain;
        }

        /// <summary>
        /// Bot Controller
        /// </summary>
        /// <param name="stock_code"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetStock")]
        public ActionResult<Stock> GetStock(string stock_code)
        {
            try
            {
                var result = StockBotService.GetStock(stock_code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

