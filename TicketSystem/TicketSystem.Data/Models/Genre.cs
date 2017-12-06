using System;

namespace TicketSystem.Data.Models
{
    [ Flags ]
    public enum Genre
    {
        Rock = 1,
        House = 2,
        GlamRock = 4,
        HeavyMetal = 8,
        TrashMetal = 16,
        PopRock = 32
    }
}