﻿using Microsoft.AspNetCore.Mvc;
using Auth.Interfaces.Services;
using DTO.ServiceCall;

namespace Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UserController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _usuarioService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("DarAltaEmpleado")]
        public async Task<IActionResult> DarAltaEmpleado(RequestActivarEmpleado dto)
        {
            Thread.Sleep(2000);
            await _usuarioService.Add(dto);
            return Ok();
        }
        [HttpPut("DarBajaEmpleado")]
        public async Task<IActionResult> DarBajaEmpleado(RequestDesactivarEmpleado dto)
        {
            Thread.Sleep(2000);
            await _usuarioService.Update(dto);
            return Ok();
        }
    }
}
