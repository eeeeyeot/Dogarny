using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startHealth = 100;

	int currentHealth;
	bool isDead;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = startHealth;
	}

	void OnEnable()
	{
		currentHealth = startHealth;
	}

	// Update is called once per frame
	void Update()
	{
		if(currentHealth < 0)
		{
			gameObject.SetActive(false);
		}
	}

	public void TakeDamage(int amount)
	{

	}

	void Death()
	{
		isDead = true;
	}
}
