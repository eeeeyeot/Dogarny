using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAIControl : MonoBehaviour {

	private NavMeshAgent agent;
	private float RemainingDistance;

	Transform target;
	
	public NavMeshAgent Agent
	{
		get
		{
			if(agent == null)
			{
				//agent = GetComponentInChildren<NavMeshAgent>();
				agent = GetComponent<NavMeshAgent>();
			}
			return agent;
		}
	}

	private void Start()
	{
		target = GameObject.FindWithTag("MainPlayer").transform;
	}

	private void Update()
	{
		target = GameObject.FindWithTag("MainPlayer").transform;

		if (target == null || target.name == transform.name)
		{
			ClearAgent();
			return;
		}

		UpdateAgent();
	}

	void ClearAgent()
	{
		Agent.ResetPath();
	}

	void UpdateAgent()
	{
		Vector3 Direction = Vector3.zero;

		if (target != null)
			Agent.SetDestination(target.position);

		RemainingDistance = Agent.remainingDistance;

		if(Agent.remainingDistance > Agent.stoppingDistance)
		{
			Direction = Agent.desiredVelocity.normalized;
		}

		//if (Direction == Vector3.zero)
		//	Move(Direction, true);
		//else
		//	Move(Direction, false);
		
	}
	
	//void Move(Vector3 move, bool active = true)
	//{
	//	if (active)
	//	{
	//		if (move.magnitude > 1f) move.Normalize();
	//		move = transform.InverseTransformDirection(move);       //convert the world relative moveInput vector into a local-relative

	//		float turnAmount = Mathf.Atan2(move.x, move.z);

	//		float forwardAmount = move.z;

	//		if (forwardAmount > 0) forwardAmount = 1;	//remove slowing down when rotating
	//		if (forwardAmount < 0) forwardAmount = -1;      //remove slowing down when rotating
	//	}
	//}
}
