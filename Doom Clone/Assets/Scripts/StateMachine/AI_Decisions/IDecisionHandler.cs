using UnityEngine;
public interface IDecisionHandler
{
    public abstract State MakeAIDecisions(AIStateMachineManager sm);
}
