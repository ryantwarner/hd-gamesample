using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Flee")]
public class FleeAction : AIAction
{
    public float fleeDistance = 6f;
    
    public override void Act(StateController controller)
    {
        Flee(controller);
    }

    private void Flee(StateController controller)
    {
        if (controller.chaseTarget != null && controller.canFlee)
        {
            Vector3 heading = controller.transform.position - controller.chaseTarget.position;
            Vector3 destination = (controller.transform.position + (heading.normalized * fleeDistance));
            destination.y = controller.transform.position.y;
            controller.SafeSetDestination(destination);
            controller.canChase = false;
            controller.canFlee = false;
        }
    }
}