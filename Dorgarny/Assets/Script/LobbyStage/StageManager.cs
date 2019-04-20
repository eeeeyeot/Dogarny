using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.AI;
using Util;

public class StageManager : Singleton<StageManager>
{
	[System.Serializable]
	public class Stage
	{
		public string stageText;
		public int unLocked;
		public bool isInteractable;
		public int stars;

	}

	public Transform chaTransform;
	public string colliderName { get; set; }
	private NavMeshAgent agent;
	private string destination;


	public List<Stage> levelList;

	public GameObject button;

	void Start()
	{
		agent = chaTransform.GetComponent<NavMeshAgent>();
		destination = "Town";
	}


	public void StageMove(Vector3 position)
	{
		agent.SetDestination(position);
	}

	public void SetDestination(string desti)
	{
		destination = desti;
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100.0f, 1 << LayerMask.NameToLayer("MoveAgent")))
			{

				SetDestination(hit.transform.name);
				StageMove(hit.transform.position);
			}
		}

	}

	public void CheckStage(string name)
	{
		colliderName = name;
		if (destination == name)
		{
			button.SetActive(true);
		}
		else
		{
			button.SetActive(false);
		}
	}
}
