using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration) {
            this.configuration = configuration;
        }
        public string GetToken(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
