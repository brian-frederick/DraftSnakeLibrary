using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Drafts
{
    public class Draft
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DraftStage Stage { get; set; }
        public DraftType Type { get; set; }
        public List<Player> OnTheClock { get; set; }
    }
}
