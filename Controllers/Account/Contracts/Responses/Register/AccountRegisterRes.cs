﻿namespace JDPodrozeAPI.Controllers.Account.Contracts.Responses
{
    public class AccountRegisterRes : IAccountRegisterRes
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}