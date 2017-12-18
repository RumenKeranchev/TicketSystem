﻿using TicketSystem.Common.Mapping;
using TicketSystem.Data.Models;

namespace TicketSystem.Services.Normal.Models.Bands.Albums.Songs
{
    public class SongShortListingServiceModel : IMapFrom< Song >
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}