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
    [Route("client-management")]
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
        public IActionResult PostClients([FromBody] LogicLayer.Models.Client client)
        {
            return Ok(_clientManager.PostClient(client));
        }
        [HttpPut]
        [Route("clients")]
        public IActionResult UpdateClients([FromBody] LogicLayer.Models.Client client)
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
        public IActionResult DeleteClients([FromBody] LogicLayer.Models.Client client)
        {
            return Ok(_clientManager.DeleteClient(client));
        }

    }
}
