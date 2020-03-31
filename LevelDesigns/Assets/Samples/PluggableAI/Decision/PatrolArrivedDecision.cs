using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/PatrolArrived")]
public class PatrolArrivedDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return Arrived(controller);
    }

    private bool Arrived(StateController controller)
    {
        float distance = Vector3.Distance(controller.transform.position, controller.wayPointList[controller.nextWayPoint].transform.position);
        return distance <= controller.navMeshAgent.stoppingDistance;
    }

}