using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyAttackDefinition demoAttack;
	public GameObject criticalParticle;

    NavMeshAgent agent;
    Animator anim;
    EnemyStats stats;

	GameObject target;
	GameObject prev_target;
    bool lockAttack;
	bool isAlive;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        stats = GetComponent<EnemyStats>();
    }

    private void OnEnable()
    {
		isAlive = true;
		lockAttack = false;
        ReleaseSpeed();
        prev_target = FindTarget();
        StartCoroutine("ManaRecovery");
    }

    void Update()
    {
		if (isAlive)
		{
			if (FindTarget() != null)
			{
				if (prev_target != target)
				{
					ReleaseSpeed();
				}
				if (target != null)
				{
					if (CanSeeTarget(target.transform.position))
					{
						SetDestination(target.transform.position);
						anim.SetInteger("LoopState", 1);

						if (CanAttackTarget(agent.remainingDistance) && !lockAttack && agent.hasPath)
						{
							Debug.Log("Enter");
							AttackTarget(target);
							agent.speed = 0f;
							agent.transform.LookAt(target.transform);

							lockAttack = true;
						}
					}
				}
				else
				{
					anim.SetInteger("LoopState", 0);
				}

				prev_target = target;
			}
		}
	}
	private void LateUpdate()
	{
		if(stats.GetHealth() <= 0){
			Death();
		}
	}

	IEnumerator ManaRecovery()
    {
        yield return new WaitForSeconds(2.0f);
        stats.IncreaseMana(stats.GetManaIncrement());
        print(stats.GetMana());
        StartCoroutine("ManaRecovery");
    }

    #region Attack Function
    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }

    public void AttackTarget(GameObject target)
    {
        var attack = demoAttack.CreateEnemyAttack(stats, target.GetComponent<PlayerStats>());
        var attackables = target.GetComponentsInChildren(typeof(iAttackable));

		Debug.Log("Critical : " + attack.IsCritical);
		if (!attack.IsCritical)
			anim.SetTrigger("Attack");
		else
		{
			anim.SetTrigger("Attack");
			ActiveParticle();
			Debug.Log("Critical");
			stats.SetCurrentMana(0);
		}

		if (attack.IsCritical)
        {
            Debug.Log("CriticalAttack");
        }

        foreach(iAttackable attackable in attackables)
        {
            attackable.OnAttack(gameObject, attack);
        }
    }

    GameObject FindTarget()
    {
        return target = GameObject.FindGameObjectWithTag("MainPlayer");
    }

    bool CanSeeTarget(Vector3 target)
    {
        float viewRange = stats.GetViewRange();
        float distance = Vector3.Distance(target, agent.transform.position);
        return (distance < viewRange) ? true : false;
    }
      
    bool CanAttackTarget(float distance)
    {
        float attackRange = stats.GetAttackRange();
        return (distance < attackRange) ? true : false;
    }
    #endregion

    public void ReleaseSpeed()
    {
        agent.speed = 1.0f;
        lockAttack = false;
		criticalParticle.SetActive(false);
    }

	void ActiveParticle(){
		criticalParticle.SetActive(true);
		ParticleSystem[] particles = criticalParticle.GetComponentsInChildren<ParticleSystem>();

		foreach(var p in particles){
			p.Play();
		}
	}

	void Death(){
		anim.SetTrigger("Die");
		agent.speed = 0f;
		isAlive = false;
	}

	void WaitForDead(){
		gameObject.SetActive(false);
	}
	
    public Animator Anim
    {
        get
        {
            return anim;
        }
    }
}
