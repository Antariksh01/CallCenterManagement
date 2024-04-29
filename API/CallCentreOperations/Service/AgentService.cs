using CallCentreOperations.Data;
using CallCentreOperations.Data.Interface;
using CallCentreOperations.Exceptions;
using CallCentreOperations.Models;
using CallCentreOperations.Service.Interface;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Linq;

namespace CallCentreOperations.Service
{
    public class AgentService : IAgentService
    {
        private readonly IDataContext _context;
        public AgentService(IDataContext context)
        {
            _context = context;
        }

        public async Task<List<Agent>> GetAgents()
        {
            var agents = await _context.Agents.ToListAsync();
            return agents;
        }

        public async Task<Agent> UpdateAgentStateAndSkills(CallCenterEvents request)
        {
            var agent = await _context.Agents.FirstOrDefaultAsync(a=>a.Id==request.AgentId && a.AgentName==request.AgentName);
            if (agent == null)
            {
                throw new LateEventException("User not found : There is no user with the matching id and name.");
            }
            agent.AgentState = CalculateAgentState(request);
            agent.Skills = request.QueueIds;
            agent.TimestampUtc = request.TimestampUtc;
            await _context.SaveChangesAsync();
            return agent;
        }

        private string CalculateAgentState(CallCenterEvents eventDto)
        {
             if (DateTime.UtcNow - eventDto.TimestampUtc > TimeSpan.FromHours(1))
            {
                throw new LateEventException("The time stamp is more than 1 hour old.");
            }

            else if (eventDto.Action == "START_DO_NOT_DISTURB" && eventDto.TimestampUtc.TimeOfDay >= TimeSpan.FromHours(11) && eventDto.TimestampUtc.TimeOfDay <= TimeSpan.FromHours(13))
            {
                return "OnLunch";
            }
            else if (eventDto.Action == "CALL_STARTED")
            {
                return "OnCall";
            }
            
            else
            {
                throw new LateEventException("Input request is not valid. Please check the action name.");
            }
        }
    }
}
