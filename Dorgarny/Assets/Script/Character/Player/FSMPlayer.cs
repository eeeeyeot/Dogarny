using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class FSMPlayer : FSMBase
{
<<<<<<< HEAD
<<<<<<< HEAD

	//public int currentHP = 100;
	//public int maxHP = 100;
	//public int exp = 0;
	//public int level = 1;
	//public int gold = 0;
	//public float attack = 40.0f;
	//public float attackRange = 1.5f;


=======
	public GameObject hitCollider;

>>>>>>> parent of 768d38e... 2019-05-19
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
<<<<<<< HEAD

	}

=======
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

>>>>>>> parent of 768d38e... 2019-05-19
=======
	}

>>>>>>> parent of 768d38e... 2019-05-19
	protected override IEnumerator Idle()
	{
		do
		{
			SetState(CharacterState.Idle);
			yield return null;
		} while (!isNewState);
	}
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 768d38e... 2019-05-19

	protected virtual IEnumerator Moving()
	{
		do
		{
			SetState(CharacterState.Moving);
			yield return null;
		} while (!isNewState);
	}

<<<<<<< HEAD
	public void Attack()
	{
		SetTrigger(CharacterState.Attack);
	}

=======
>>>>>>> parent of 768d38e... 2019-05-19
	protected virtual IEnumerator Dead()
	{
		do
		{

			yield return null;
		} while (!isNewState);
	}

<<<<<<< HEAD
	protected virtual IEnumerator Skill1()
	{
		do
		{
=======

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

>>>>>>> parent of 768d38e... 2019-05-19
			yield return null;
		} while (!isNewState);
	}

<<<<<<< HEAD
	protected virtual IEnumerator Skill2()
	{
		do
		{
			yield return null;
		} while (!isNewState);
	}

	public void OnAutoAtack()
	{
		if (lockAttack) return;

		Debug.Log("Auto Attack");
		Attack();
		lockAttack = true;
=======
=======
>>>>>>> parent of 768d38e... 2019-05-19
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
<<<<<<< HEAD
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
	}

	public void RealeseAttack()
	{
<<<<<<< HEAD
<<<<<<< HEAD
		lockAttack = false;
=======
		PlayerMovement.instance.moveSpeed = 2.0f;
		lockAttack = false;
		hitCollider.SetActive(false);
>>>>>>> parent of 768d38e... 2019-05-19
=======
		PlayerMovement.instance.moveSpeed = 2.0f;
		lockAttack = false;
		hitCollider.SetActive(false);
>>>>>>> parent of 768d38e... 2019-05-19
	}
}
