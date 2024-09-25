using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IAuthService authService;

        public UsuarioController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("logar")]
        [AllowAnonymous]
        public string login([FromBody] LogarRequest request)
        {
            return authService.logar(request.Email,request.Senha);
        }

        [HttpPost("registrar")]
        [AllowAnonymous]
        public string registrar([FromBody] RegistrarRequest request)
        {
            authService.registrar(request.Email, request.Senha);
            return "teste";
        }
    }
}
