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
        [HttpPost]
        [Route("clients")]
        public IActionResult PostClients(Client client)
        {
            return Ok(_clientManager.PostClient(client));
        }
        [HttpPut]
        [Route("clients")]
        public IActionResult UpdateClients(Client client)
        {
            if (_clientManager.UpdateClient(client) != null)
            {
                return Ok(_clientManager.UpdateClient(client));
            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete]
        [Route("clients")]
        public IActionResult DeleteClients(Client client)
        {
            return Ok(_clientManager.DeleteClient(client));
        }

    }
}
