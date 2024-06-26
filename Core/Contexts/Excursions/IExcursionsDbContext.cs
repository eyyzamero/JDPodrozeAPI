﻿using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Contexts.Excursions
{
    public interface IExcursionsDbContext
    {
        public DbSet<ExcursionDTO> Excursions { get; set; }
        public DbSet<ExcursionImageDTO> ExcursionsImages { get; set; }
        public DbSet<ExcursionOrderDTO> ExcursionsOrders { get; set; }
        public DbSet<ExcursionParticipantDTO> ExcursionsParticipants { get; set; }
        public DbSet<ExcursionPickupPointDTO> ExcursionsPickupPoints { get; set; }
    }
}