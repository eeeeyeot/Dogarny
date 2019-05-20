using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButtonManagement : MonoBehaviour
{
	Button thisBtn;
	GameObject mainPlayer;
	private void Start()
	{
		mainPlayer = GameObject.FindWithTag("MainPlayer");
		thisBtn = GetComponent<Button>();
		thisBtn.onClick.AddListener(
			() =>
			{
				mainPlayer.GetComponent<FSMPlayer>().OnAutoAtack();
			}
		);
	}

	private void Update()
	{
		if(mainPlayer == null)
		{
			mainPlayer = GameObject.FindWithTag("MainPlayer");
		}	


		if (mainPlayer.tag != GameObject.FindWithTag("MainPlayer").tag)
		{
			mainPlayer = GameObject.FindWithTag("MainPlayer");
			thisBtn.onClick.RemoveAllListeners();
		}
		else
		{
			return;
		}

		thisBtn.onClick.AddListener(
			() =>
			{
				mainPlayer.GetComponent<FSMPlayer>().OnAutoAtack();
			}
		);
	}
}
