﻿namespace JDPodrozeAPI.Services.Excursions.Contracts.Responses
{
    public interface IExcursionsServiceGetListItemImageRes
    {
        public int Id { get; set; }
        public int ExcursionId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Order { get; set; }
    }
}