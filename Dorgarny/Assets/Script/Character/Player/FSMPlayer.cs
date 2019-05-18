using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class FSMPlayer : FSMBase
{
    public GameObject hitCollider;
    public GameObject attackEffect;
    public Transform effectPos;

    private Vector3 forward;
    private Ray ray;

	private void Start()
	{
		if (hitCollider != null)
			hitCollider.GetComponent<HitCollider>().player = GetComponent<PlayerStats>();
	}

	private void LateUpdate()
    {
        if (GetComponent<NavMeshAgent>().velocity != Vector3.zero)
        {
            CHState = CharacterState.Moving;
        }
        else
        {
            CHState = CharacterState.Idle;
        }
    }

    protected override IEnumerator Idle()
    {
        do
        {
            SetState(CharacterState.Idle);
            yield return null;
        } while (!isNewState);
    }

    protected virtual IEnumerator Moving()
    {
        do
        {
            SetState(CharacterState.Moving);
            yield return null;
        } while (!isNewState);
    }

    protected virtual IEnumerator Dead()
    {
        do
        {

            yield return null;
        } while (!isNewState);
    }

    public void OnAutoAtack()
    {
        if (lockAttack) return;

        GetComponent<NavMeshAgent>().speed = 1.0f;
        if (gameObject.tag == "MainPlayer")
        {
            PlayerMovement.instance.moveSpeed = 1.0f;
        }

        Attack();
        lockAttack = true;
        if (hitCollider != null)
            hitCollider.SetActive(true);
    }

    public void Attack()
    {
        SetTrigger(CharacterState.Attack);
    }

    public void RealeseAttack()
    {
        GetComponent<NavMeshAgent>().speed = 2.0f;
        if (gameObject.tag == "MainPlayer")
        {
            PlayerMovement.instance.moveSpeed = 2.0f;
        }
        lockAttack = false;
        if (hitCollider != null)
            hitCollider.SetActive(false);
    }

    public void ActiveAttackEffect()
    {
        GameObject projectile = Instantiate(attackEffect, effectPos.position, transform.rotation) as GameObject;
        
        if (gameObject.name == "Wizard")
        {
            forward = transform.forward;
            StartCoroutine("MoveForward", projectile);
        }
        else if(gameObject.name == "Archer")
        {
            RaycastHit hit;
            forward = transform.position;
            forward.y += 0.2f;
            if(Physics.Raycast(transform.position, forward, out hit))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyStats>().TakeDamage(GetComponent<PlayerStats>().GetDamage());
                }
            }
        }
    }

    IEnumerator MoveForward(GameObject _effect)
    {
        while (_effect != null)
        {
            
            yield return _effect.transform.position += forward * Constants.fireballSpeed * Time.deltaTime;
        }
    }
}
