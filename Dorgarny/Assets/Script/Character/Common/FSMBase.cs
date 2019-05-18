using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class FSMBase : MonoBehaviour {
	//Animator 컴포넌트를 제어하는 변수
	public Animator anim;
	//bool isHit = false;
	protected bool lockAttack = false;


	//개체 (몬스터, 캐릭터 등)의 상태변화를 제어하는 변수
	private CharacterState chState;
	
	public CharacterState CHState
	{
		get
		{
			return chState;
		}
		set
		{
			chState = value;
		}
	}

	//개체의 상태가 바꼈는지 체크하는 변수
	public bool isNewState;

	protected virtual void Awake()
	{
		anim = GetComponent<Animator>();
	}


	//모든 개체는 씬에 생성되는 순간 Idle 상태가 되며, FSMMain 코루틴 메소드를 실행
	protected virtual void OnEnable()
	{
		CHState = CharacterState.Idle;
		StartCoroutine(FSMMain());
	}

	IEnumerator FSMMain()
	{
		//상태가 바뀌면 IEnumerator CHState.ToString() 메소드를 실행한다.
		//처음은 IEnumerator Idle() 실행
		while (true)
		{
			isNewState = false;
			//if (gameObject.tag == "MainPlayer")
			yield return StartCoroutine(CHState.ToString());
		}
	}
	

	//개체의 상태가 바뀔때마다 메소드가 실행된다.
	public void SetState(CharacterState newState)
	{
		isNewState = true;
		CHState = newState;

		//개체가 가진 Animator 컴포넌트의 state Parameters 에게 상태 변화 값을 전달한다.
		anim.SetInteger("LoopState", (int)CHState);
	}

	public void SetTrigger(CharacterState newState)
	{
		CHState = newState;
		anim.SetTrigger(newState.ToString());
	}
	
	//모든 개체는 Idle 상태를 가진다.
	protected virtual IEnumerator Idle()
	{
		do
		{
			//1프레임에 한번만 체크
			yield return null;
		} while (!isNewState); //do 문 종료조건
	}

	//상태변화 체크를 코루틴으로 처리한다.

	//다른 책에서는 상태변화를 Case 문으로 구현하는데, 여기서는 코루틴으로 처리합니다.
	//그 이유는 상태가 많아질 수록 코루틴을 사용하는 것이 가독성이 좋기 때문입니다.
	//몰론 사람마다 취향이 다르기 때문에 무엇이 더 가독성이 높다고 말할 수 는 없겠네요.



	//FSMMain() 는 상태변화에 따른 코루틴 실행을 담당.

	//FSMMain()은 바뀐 상태에 따라
	//protected virtual IEnumerator Idle, protected virtual IEnumerator AttackRun, protected virtual IEnumerator Dead
	//등의 코루틴 메소드를 실행한다.
	//Attack, Dead 등은 공통으로 사용하지 않기 때문에 FSMBase.cs 에 작성하지 않았음.



	//SetState(CharacterState newState) 에서 상태변화 를 담당.

	//바뀐 상태에 따른 애니메이션 실행 및 State 변화를 담당한다.

}
