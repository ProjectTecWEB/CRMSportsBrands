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
        public Log elog; 
        public ClientsController(ClientManager clientManager)
        {
            _clientManager = clientManager;
            elog = new Log(@"S:\TecWeb\proyecto3\CRMSportsBrands\");
        }
        [HttpGet]
        [Route("clients")]
        public IActionResult GetClients()
        {
            elog.Add("Se obtuvo un get");
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
                elog.Add("No se pudo realizar el Update");
                return NotFound("El id ingresado no esta asociado a ningun cliente");
            }

        }
        [HttpDelete]
        [Route("clients")]
        public IActionResult DeleteClients([FromBody] LogicLayer.Models.Client client)
        {
            if(_clientManager.DeleteClient(client) ==null)
            {
                elog.Add("No se pudo realizar el delete");
                return NotFound("El id ingresado no esta asociado a ningun cliente");
            }
            return Ok(_clientManager.DeleteClient(client));
        }

       [HttpGet]
        [Route("external-client")]
        public IActionResult GetExternalClient()
        {
            
         return Ok(_clientManager.GetExternalClient());
        }

    }
}
