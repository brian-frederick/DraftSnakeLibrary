using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Picks
{
    public class Pick
    {
        public string DraftId { get; set; }
        public int OverallOrder { get; set; }
        public string PlayerId { get; set; }
        public string Selection { get; set; }
    }
}
