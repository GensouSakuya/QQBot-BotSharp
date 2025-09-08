using BotSharp.Abstraction.Loggers.Models;

namespace BotSharp.Core.Loggers.Services;

public partial class LoggerService
{
    public async Task<PagedItems<InstructionLogModel>> GetInstructionLogs(InstructLogFilter filter)
    {
        if (filter == null)
        {
            filter = InstructLogFilter.Empty();
        }

        var db = _services.GetRequiredService<IBotSharpRepository>();
        var agentService = _services.GetRequiredService<IAgentService>();
        var logs = await db.GetInstructionLogs(filter);
        var agentIds = logs.Items.Where(x => !string.IsNullOrEmpty(x.AgentId)).Select(x => x.AgentId).ToList();
        var userIds = logs.Items.Where(x => !string.IsNullOrEmpty(x.UserId)).Select(x => x.UserId).ToList();
        var agents = await agentService.GetAgentOptions(agentIds);

        var items = logs.Items.Select(x =>
        {
            x.AgentName = !string.IsNullOrEmpty(x.AgentId) ? agents.FirstOrDefault(a => a.Id == x.AgentId)?.Name : null;

            return x;
        }).ToList();

        return new PagedItems<InstructionLogModel>
        {
            Items = items,
            Count = logs.Count
        };
    }

    public async Task<List<string>> GetInstructionLogSearchKeys(InstructLogKeysFilter filter)
    {
        if (filter == null)
        {
            filter = InstructLogKeysFilter.Empty();
        }

        var keys = new List<string>();
        if (!filter.PreLoad && string.IsNullOrWhiteSpace(filter.Query))
        {
            return keys;
        }

        var db = _services.GetRequiredService<IBotSharpRepository>();

        keys = db.GetInstructionLogSearchKeys(filter);
        keys = filter.PreLoad ? keys : keys.Where(x => x.Contains(filter.Query ?? string.Empty, StringComparison.OrdinalIgnoreCase)).ToList();
        return keys.OrderBy(x => x).Take(filter.KeyLimit).ToList();
    }
}
