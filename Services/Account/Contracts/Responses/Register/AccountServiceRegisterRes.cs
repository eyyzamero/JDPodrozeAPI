﻿namespace JDPodrozeAPI.Services.Account.Contracts.Responses
{
    public class AccountServiceRegisterRes : IAccountServiceRegisterRes
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}