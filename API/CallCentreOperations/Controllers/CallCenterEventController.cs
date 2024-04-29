using CallCentreOperations.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CallCentreOperations.Data;
using CallCentreOperations.Service.Interface;
using CallCentreOperations.Exceptions;

namespace CallCentreOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallCenterEventController : ControllerBase
    {
       
        private IAgentService _agentService;
        public CallCenterEventController( IAgentService agentService)
        {
            
            _agentService = agentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Agent>>> GetAgents()
        {
            return await _agentService.GetAgents();
        }

        [HttpPut("UpdateAgent")]
        public async Task<ActionResult> UpdateAgent(CallCenterEvents request)
        {
            
            try
            {
                var agents = await _agentService.UpdateAgentStateAndSkills(request);
                return Ok(agents);
            }
            catch (LateEventException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
