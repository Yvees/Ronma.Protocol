namespace Ronma.Protocol.Enums
{
    public enum AgentEventType
    {
        UserInput,
        Intervention,
        ServiceResult,
        FollowUp,
        System
    }

    public enum AgentActionType
    {
        Think,
        ServiceCall,
        FollowUp,
        Final,
        Error
    }
}
