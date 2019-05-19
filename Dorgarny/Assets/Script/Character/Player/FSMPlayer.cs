using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class FSMPlayer : FSMBase
{
	public GameObject hitCollider;

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

		PlayerMovement.instance.moveSpeed = 1.0f;
		
		Attack();
		lockAttack = true;
		hitCollider.SetActive(true);
	}

	public void Attack()
	{
		SetTrigger(CharacterState.Attack);
	}

	public void RealeseAttack()
	{
		PlayerMovement.instance.moveSpeed = 2.0f;
		lockAttack = false;
		hitCollider.SetActive(false);
	}
}
