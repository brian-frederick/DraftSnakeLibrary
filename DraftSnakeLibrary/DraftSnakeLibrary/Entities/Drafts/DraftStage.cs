﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DraftSnakeLibrary.Entities.Drafts
{
    public enum DraftStage
    {
        AwaitingPlayers = 1,
        Drafting = 2,
        Voting = 3,
        Closed = 4
    }
}
