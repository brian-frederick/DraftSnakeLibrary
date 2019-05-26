using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Messages
{
    public abstract class Message
    {
        public string DraftId { get; set; }
        public MessageType MessageType { get; set; }
    }
}
