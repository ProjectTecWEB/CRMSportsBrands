using System;
using Logic.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CsmSport.Controllers
{
    [Route("Clientes-management")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private ClientesManager _userManager;
        public ClientesController(ClientesManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Clientes")]
        public IActionResult GetClientes() 
        {
            return Ok(_userManager.GetClientes());
        }

        [HttpGet]
        [Route("id-clientes")]
        public IActionResult GetIdNumber()
        {
            return Ok(_userManager.GetSSN());
        }
    }
}