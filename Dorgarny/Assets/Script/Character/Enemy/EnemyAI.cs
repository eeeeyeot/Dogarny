using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
	NavMeshAgent agent;
	Animator anim;

	GameObject target;

	public float viewRange;
	public float attackRange;

	bool lockAttack;

	void Start()
	{
		lockAttack = false;
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();

		target = GameObject.FindGameObjectWithTag("MainPlayer");
		agent.SetDestination(target.transform.position);
		agent.velocity = Vector3.zero;
	}

	void Update()
	{
		target = GameObject.FindGameObjectWithTag("MainPlayer");

		if (target != null)
		{
			if (CanSeeTarget(agent.remainingDistance))
			{
				agent.SetDestination(target.transform.position);
				anim.SetInteger("LoopState", 1);

				if (CanAttackTarget(agent.remainingDistance) && !lockAttack)
				{
					agent.speed = 0f;
					agent.transform.LookAt(target.transform);
					anim.SetTrigger("Attack");

					lockAttack = true;
				}
			}
			else
			{
				anim.SetInteger("LoopState", 0);

			}
		}
	}

	public void ReleaseSpeed()
	{
		agent.speed = 1.0f;
		lockAttack = false;
	}

	//True => Follow the target, False => Do not follow the target
	bool CanSeeTarget(float distance)
	{
		return (distance < viewRange) ? true : false;
	}

	//True => Attack the target, False => Do not attack the target
	bool CanAttackTarget(float distance)
	{
		return (distance < attackRange) ? true : false;
	}

}
