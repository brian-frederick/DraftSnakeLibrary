using DraftSnakeLibrary.Entities.Drafts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Messages
{
    public class DraftCreatedMessage
    {
        public Draft draft { get; set; }
    }
}
