﻿namespace Application.Identity.Models
{
    public class AuthenticateUserCommand
    {
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
