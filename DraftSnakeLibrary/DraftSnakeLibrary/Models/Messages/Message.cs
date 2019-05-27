using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Messages
{
    public abstract class Message
    {
        public string DraftId { get; set; }
        public MessageType MessageType { get; set; }
    }
}
