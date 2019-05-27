using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Players
{
    public class Player
    {
        public string DraftId { get; set; }
        public string Name { get; set; }
        public string ConnectionId { get; set; }
        public Boolean IsConnected { get; set; }
    }
}
