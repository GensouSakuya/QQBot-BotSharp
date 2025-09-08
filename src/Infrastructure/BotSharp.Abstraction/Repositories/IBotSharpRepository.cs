using BotSharp.Abstraction.Loggers.Models;
using BotSharp.Abstraction.Plugins.Models;
using BotSharp.Abstraction.Repositories.Filters;
using BotSharp.Abstraction.Roles.Models;
using BotSharp.Abstraction.Shared;
using BotSharp.Abstraction.Statistics.Enums;
using BotSharp.Abstraction.Statistics.Models;
using BotSharp.Abstraction.Tasks.Models;
using BotSharp.Abstraction.Translation.Models;
using BotSharp.Abstraction.VectorStorage.Models;

namespace BotSharp.Abstraction.Repositories;

public interface IBotSharpRepository : IHaveServiceProvider
{
    #region Plugin
    PluginConfig GetPluginConfig()
        => throw new NotImplementedException();
    void SavePluginConfig(PluginConfig config)
        => throw new NotImplementedException();
    #endregion

    #region Role
    bool RefreshRoles(IEnumerable<Role> roles)
        => throw new NotImplementedException();
    IEnumerable<Role> GetRoles(RoleFilter filter)
        => throw new NotImplementedException();
    Role? GetRoleDetails(string roleId, bool includeAgent = false)
        => throw new NotImplementedException();
    bool UpdateRole(Role role, bool updateRoleAgents = false)
        => throw new NotImplementedException();
    #endregion

    #region Agent
    void UpdateAgent(Agent agent, AgentField field)
        => throw new NotImplementedException();
    Agent? GetAgent(string agentId, bool basicsOnly = false)
        => throw new NotImplementedException();
    List<Agent> GetAgents(AgentFilter filter)
        => throw new NotImplementedException();
    void BulkInsertAgents(List<Agent> agents)
        => throw new NotImplementedException();
    void BulkInsertUserAgents(List<UserAgent> userAgents)
        => throw new NotImplementedException();
    bool DeleteAgents()
        => throw new NotImplementedException();
    bool DeleteAgent(string agentId)
        => throw new NotImplementedException();
    List<string> GetAgentResponses(string agentId, string prefix, string intent)
        => throw new NotImplementedException();
    string GetAgentTemplate(string agentId, string templateName)
        => throw new NotImplementedException();
    bool PatchAgentTemplate(string agentId, AgentTemplate template)
        => throw new NotImplementedException();

    bool UpdateAgentLabels(string agentId, List<string> labels)
        => throw new NotImplementedException();
    bool AppendAgentLabels(string agentId, List<string> labels)
        => throw new NotImplementedException();
    #endregion

    #region Agent Task
    ValueTask<PagedItems<AgentTask>> GetAgentTasks(AgentTaskFilter filter)
        => throw new NotImplementedException();
    AgentTask? GetAgentTask(string agentId, string taskId)
        => throw new NotImplementedException();
    void InsertAgentTask(AgentTask task)
        => throw new NotImplementedException();
    void BulkInsertAgentTasks(List<AgentTask> tasks)
        => throw new NotImplementedException();
    void UpdateAgentTask(AgentTask task, AgentTaskField field)
        => throw new NotImplementedException();
    bool DeleteAgentTask(string agentId, List<string> taskIds)
        => throw new NotImplementedException();
    bool DeleteAgentTasks()
        => throw new NotImplementedException();
    #endregion

    #region Conversation
    void CreateNewConversation(Conversation conversation)
        => throw new NotImplementedException();
    bool DeleteConversations(IEnumerable<string> conversationIds)
        => throw new NotImplementedException();
    List<DialogElement> GetConversationDialogs(string conversationId)
        => throw new NotImplementedException();
    void AppendConversationDialogs(string conversationId, List<DialogElement> dialogs)
        => throw new NotImplementedException();
    ConversationState GetConversationStates(string conversationId)
        => throw new NotImplementedException();
    void UpdateConversationStates(string conversationId, List<StateKeyValue> states)
        => throw new NotImplementedException();
    void UpdateConversationStatus(string conversationId, string status)
        => throw new NotImplementedException();
    Conversation GetConversation(string conversationId, bool isLoadStates = false)
        => throw new NotImplementedException();
    ValueTask<PagedItems<Conversation>> GetConversations(ConversationFilter filter)
        => throw new NotImplementedException();
    void UpdateConversationTitle(string conversationId, string title)
        => throw new NotImplementedException();
    void UpdateConversationTitleAlias(string conversationId, string titleAlias)
        => throw new NotImplementedException();
    bool UpdateConversationTags(string conversationId, List<string> toAddTags, List<string> toDeleteTags)
        => throw new NotImplementedException();
    bool AppendConversationTags(string conversationId, List<string> tags)
        => throw new NotImplementedException();
    bool UpdateConversationMessage(string conversationId, UpdateMessageRequest request)
        => throw new NotImplementedException();
    void UpdateConversationBreakpoint(string conversationId, ConversationBreakpoint breakpoint)
        => throw new NotImplementedException();
    ConversationBreakpoint? GetConversationBreakpoint(string conversationId)
        => throw new NotImplementedException();
    List<Conversation> GetLastConversations()
        => throw new NotImplementedException();
    List<string> GetIdleConversations(int batchSize, int messageLimit, int bufferHours, IEnumerable<string> excludeAgentIds)
         => throw new NotImplementedException();
    List<string> TruncateConversation(string conversationId, string messageId, bool cleanLog = false)
         => throw new NotImplementedException();
    List<string> GetConversationStateSearchKeys(ConversationStateKeysFilter filter)
         => throw new NotImplementedException();
    List<string> GetConversationsToMigrate(int batchSize = 100)
        => throw new NotImplementedException();
    bool MigrateConvsersationLatestStates(string conversationId)
         => throw new NotImplementedException();
    #endregion

    #region LLM Completion Log
    void SaveLlmCompletionLog(LlmCompletionLog log)
        => throw new NotImplementedException();
    #endregion

    #region Conversation Content Log
    void SaveConversationContentLog(ContentLogOutputModel log)
        => throw new NotImplementedException();
    DateTimePagination<ContentLogOutputModel> GetConversationContentLogs(string conversationId, ConversationLogFilter filter)
        => throw new NotImplementedException();
    #endregion

    #region Conversation State Log
    void SaveConversationStateLog(ConversationStateLogModel log)
        => throw new NotImplementedException();
    DateTimePagination<ConversationStateLogModel> GetConversationStateLogs(string conversationId, ConversationLogFilter filter)
        => throw new NotImplementedException();
    #endregion

    #region Instruction Log
    bool SaveInstructionLogs(IEnumerable<InstructionLogModel> logs)
        => throw new NotImplementedException();

    ValueTask<PagedItems<InstructionLogModel>> GetInstructionLogs(InstructLogFilter filter)
        => throw new NotImplementedException();

    List<string> GetInstructionLogSearchKeys(InstructLogKeysFilter filter)
         => throw new NotImplementedException();
    #endregion

    #region Statistics
    BotSharpStats? GetGlobalStats(string agentId, DateTime recordTime, StatsInterval interval)
        => throw new NotImplementedException();
    bool SaveGlobalStats(BotSharpStatsDelta delta)
        => throw new NotImplementedException();

    #endregion

    #region Translation
    IEnumerable<TranslationMemoryOutput> GetTranslationMemories(IEnumerable<TranslationMemoryQuery> queries)
         => throw new NotImplementedException();
    bool SaveTranslationMemories(IEnumerable<TranslationMemoryInput> inputs)
         => throw new NotImplementedException();

    #endregion

    #region KnowledgeBase
    /// <summary>
    /// Save knowledge collection configs. If reset is true, it will remove everything and then save the new configs.
    /// </summary>
    /// <param name="configs"></param>
    /// <param name="reset"></param>
    /// <returns></returns>
    bool AddKnowledgeCollectionConfigs(List<VectorCollectionConfig> configs, bool reset = false)
         => throw new NotImplementedException();
    bool DeleteKnowledgeCollectionConfig(string collectionName)
         => throw new NotImplementedException();
    IEnumerable<VectorCollectionConfig> GetKnowledgeCollectionConfigs(VectorCollectionConfigFilter filter)
         => throw new NotImplementedException();
    bool SaveKnolwedgeBaseFileMeta(KnowledgeDocMetaData metaData)
         => throw new NotImplementedException();

    /// <summary>
    /// Delete file meta data in a knowledge collection, given the vector store provider. If "fileId" is null, delete all in the collection.
    /// </summary>
    /// <param name="collectionName"></param>
    /// <param name="vectorStoreProvider"></param>
    /// <param name="fileId"></param>
    /// <returns></returns>
    bool DeleteKnolwedgeBaseFileMeta(string collectionName, string vectorStoreProvider, Guid? fileId = null)
         => throw new NotImplementedException();
    ValueTask<PagedItems<KnowledgeDocMetaData>> GetKnowledgeBaseFileMeta(string collectionName, string vectorStoreProvider, KnowledgeFileFilter filter)
         => throw new NotImplementedException();
    #endregion

    #region Crontab
    bool UpsertCrontabItem(CrontabItem cron)
        => throw new NotImplementedException();
    bool DeleteCrontabItem(string conversationId)
        => throw new NotImplementedException();
    ValueTask<PagedItems<CrontabItem>> GetCrontabItems(CrontabItemFilter filter)
        => throw new NotImplementedException();
    #endregion
}
