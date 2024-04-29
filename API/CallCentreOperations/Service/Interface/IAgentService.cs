using CallCentreOperations.Models;

namespace CallCentreOperations.Service.Interface
{
    public interface IAgentService
    {
        public Task<Agent> UpdateAgentStateAndSkills(CallCenterEvents request);
        public Task<List<Agent>> GetAgents();
    }
}
