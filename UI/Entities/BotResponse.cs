using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Entities
{
    public class BotResponse
    {
        public bool IsSuccessful { get; set; }
        public bool Detected { get; set; }
        public string ErrorMessage { get; set; }
        public string Symbol { get; set; }
        public string Close { get; set; }
    }
}
