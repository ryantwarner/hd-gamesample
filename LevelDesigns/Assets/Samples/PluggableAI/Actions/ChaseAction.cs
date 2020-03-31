using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : AIAction
{

    public float followDistance = 2f;

    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        if (controller.chaseTarget != null)
        {
            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance || controller.canChase)
            {
                Vector3 distanceVector = controller.transform.position - controller.chaseTarget.position;
                Vector3 distanceVectorNormalized = distanceVector.normalized;
                Vector3 targetPosition = (distanceVectorNormalized * followDistance);
                controller.SafeSetDestination(controller.chaseTarget.position + targetPosition);
                controller.canChase = false;
                controller.canFlee = false;
            }
        }
    }

}