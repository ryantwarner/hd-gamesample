using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationTest : MonoBehaviour
{

    StateController stateController;

    // Start is called before the first frame update
    void Start()
    {
        stateController = GetComponent<StateController>();
        stateController.navMeshAgent.SetDestination(new Vector3(10, 0, 10));
    }
}
