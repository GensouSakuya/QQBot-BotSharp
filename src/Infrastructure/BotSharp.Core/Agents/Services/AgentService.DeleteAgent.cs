namespace BotSharp.Core.Agents.Services;

public partial class AgentService
{
    public async Task<bool> DeleteAgent(string id)
    {
        var deleted = _db.DeleteAgent(id);
        return await Task.FromResult(deleted);
    }
}
