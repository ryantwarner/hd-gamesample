using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{

    public float radius = 3f;
    public bool trackTarget = true;
    public LayerMask layerMask;

    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        Collider[] hitColliders = Physics.OverlapSphere(controller.transform.position, radius, layerMask);
        if (hitColliders.Length > 0)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].CompareTag("Player"))
                {
                    controller.chaseTarget = hitColliders[i].transform;
                    controller.canFlee = true;
                    controller.canChase = true;
                    return true;
                }
            }
        }
        controller.chaseTarget = trackTarget ? controller.chaseTarget : null;
        return false;
    }

}