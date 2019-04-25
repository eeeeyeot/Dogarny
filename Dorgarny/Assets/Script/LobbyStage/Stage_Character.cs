using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stage_Character : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        StageManager.Instance.CheckStage(other.name);
    }

	void Update()
	{
		if(GetComponent<NavMeshAgent>().velocity != Vector3.zero)
		{
			GetComponent<Animator>().SetInteger("LoopState", 1);
		}
		else
		{
			GetComponent<Animator>().SetInteger("LoopState", 0);
		}
	}
}
