using DraftSnakeLibrary.Models.Players;
using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Models.Drafts
{
    public class Draft
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DraftStage Stage { get; set; }
        public DraftType Type { get; set; }
        public List<Player> DraftOrder { get; set; }
        public int CurrentRound { get; set; }
        public int TotalRounds { get; set; }
        public RoundDirection CurrentDirection { get; set; }
    }

    public enum RoundDirection
    {
        Forward = 1,
        Backward = 2 
    }

    public enum DraftStage
    {
        AwaitingPlayers = 1,
        Drafting = 2,
        Voting = 3,
        Closed = 4
    }

    public enum DraftType
    {
        Socket = 1,
        Email = 2,
        Text = 3
    }
}
