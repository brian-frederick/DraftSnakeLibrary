using DraftSnakeLibrary.Entities.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Messages
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
