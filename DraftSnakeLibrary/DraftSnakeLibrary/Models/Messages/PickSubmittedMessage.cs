using DraftSnakeLibrary.Models.Picks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Messages
{
    public class PickSubmittedMessage : Message
    {
        public Pick Pick { get; set; }

        public PickSubmittedMessage()
        {
            MessageType = MessageType.PickSubmitted;
        }

        public PickSubmittedMessage(Pick pick)
        {
            MessageType = MessageType.PickSubmitted;
            Pick = pick;
        }
    }
}
