using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour {

	public State currentState;
	public Transform eyes;
	public State remainState;

	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public List<Transform> wayPointList;
	[HideInInspector] public int nextWayPoint = 0;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	public bool aiActive;
	public bool isPatroling = false;

	public bool canChase = false;
	public bool canFlee = false;

	private float navMeshHitDistance = 1f;

	void Awake () 
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		SafeSetDestination(transform.position);
	}

	public void SetupAI(bool aiActivationFromTankManager, List<Transform> wayPointsFromTankManager)
	{
		wayPointList = wayPointsFromTankManager;
		aiActive = aiActivationFromTankManager;
		if (aiActive) 
		{
			navMeshAgent.enabled = true;
		} else 
		{
			navMeshAgent.enabled = false;
		}
	}

	public void TransitionToState(State nextState)
	{
		if (nextState == remainState) return;
		currentState = nextState;
		OnExitState();
	}

	public bool CheckIfCountDownElapsed(float duration)
	{
		stateTimeElapsed += Time.deltaTime;
		return stateTimeElapsed >= duration;
	}

	void Update()
	{
		if (!aiActive) return;

		currentState.UpdateState(this);
	}

	void OnExitState()
	{
		stateTimeElapsed = 0;
	}

	void OnDrawGizmos()
	{
		if (currentState != null && eyes != null)
		{
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere(eyes.position, 3f);
		}
	}

	public void SafeSetDestination(Vector3 destination)
	{
		NavMeshHit hit;
		if (NavMesh.SamplePosition(destination, out hit, navMeshHitDistance, NavMesh.AllAreas))
		{
			navMeshAgent.destination = hit.position;
			navMeshAgent.isStopped = false;
		}
	}

}