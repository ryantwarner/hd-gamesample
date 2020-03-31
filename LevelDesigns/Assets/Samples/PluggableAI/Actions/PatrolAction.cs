using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class PatrolAction : AIAction
{
    public override void Act(StateController controller)
    {
        Patrol(controller);
    }

    void Patrol(StateController controller)
    {
        if (controller.chaseTarget == null)
        {
            if (!controller.navMeshAgent.pathPending)
            {
                if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance)
                {
                    controller.SafeSetDestination(controller.wayPointList[controller.nextWayPoint].position);
                }
            }
        }
    }

}