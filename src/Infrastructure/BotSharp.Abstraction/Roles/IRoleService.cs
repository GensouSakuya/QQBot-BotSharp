using BotSharp.Abstraction.Repositories.Filters;
using BotSharp.Abstraction.Roles.Models;

namespace BotSharp.Abstraction.Roles;

public interface IRoleService
{
    Task<Role?> GetRoleDetails(string roleId, bool includeAgent = false);
    Task<bool> UpdateRole(Role role, bool isUpdateRoleAgents = false);
}
