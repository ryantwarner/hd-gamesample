using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/NextWaypoint")]
public class NextWaypointAction : AIAction
{
    public override void Act(StateController controller)
    {
        Next(controller);
    }

    private void Next(StateController controller)
    {
        controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
    }
}