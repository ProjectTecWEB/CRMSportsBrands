using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer.Managers;
using DBLayer.Models;

namespace CRMSportsBrands.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private ClientManager _clientManager;
        public ClientsController(ClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        [HttpGet]
        [Route("clients")]
        public IActionResult GetClients()
        {
            return Ok(_clientManager.GetClients());
        }
        
    }
}
