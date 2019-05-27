using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Messages
{
    public class PlayerCreatedMessage : Message
    {
        public Player NewPlayer { get; set; }

        public PlayerCreatedMessage()
        {
            MessageType = MessageType.PlayerCreated;
        }
    }  
}
