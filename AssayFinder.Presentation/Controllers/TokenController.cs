using AssayFinder.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssayFinder.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service) => _service = service;

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDTO)
        {
            var tokenDtoToReturn = await _service.AuthenticationService.RefreshToken(tokenDTO);

            return Ok(tokenDtoToReturn);
        }
    }

    
}
