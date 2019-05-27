using DraftSnakeLibrary.Models.Drafts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Messages
{
    public class DraftCreatedMessage
    {
        public Draft draft { get; set; }
    }
}
