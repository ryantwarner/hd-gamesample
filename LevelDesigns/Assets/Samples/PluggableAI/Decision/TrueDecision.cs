using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/True")]
public class TrueDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return true;
    }
}