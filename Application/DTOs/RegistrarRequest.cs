﻿namespace API.Controllers
{
    public class RegistrarRequest
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}