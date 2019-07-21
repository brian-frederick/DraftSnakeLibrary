using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Picks
{
    public class Pick
    {
        public string DraftId { get; set; }
        public int Id { get; set; }
        public string PlayerId { get; set; }
        public string Selection { get; set; }
    }
}
