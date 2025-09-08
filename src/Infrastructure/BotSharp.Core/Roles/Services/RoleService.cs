using System.Reflection;

namespace BotSharp.Core.Roles.Services;

public class RoleService : IRoleService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<RoleService> _logger;

    public RoleService(
        IServiceProvider services,
        ILogger<RoleService> logger)
    {
        _services = services;
        _logger = logger;
    }


    public async Task<Role?> GetRoleDetails(string roleId, bool includeAgent = false)
    {
        var db = _services.GetRequiredService<IBotSharpRepository>();
        var role = db.GetRoleDetails(roleId, includeAgent);
        return role;
    }

    public async Task<bool> UpdateRole(Role role, bool isUpdateRoleAgents = false)
    {
        if (role == null) return false;

        if (string.IsNullOrEmpty(role.Id))
        {
            role.Id = Guid.NewGuid().ToString();
        }
        
        var db = _services.GetRequiredService<IBotSharpRepository>();
        return db.UpdateRole(role, isUpdateRoleAgents);
    }
}
