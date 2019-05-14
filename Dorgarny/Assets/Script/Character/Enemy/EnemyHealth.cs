using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public float startHealth = 100f;

	float currentHealth;
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

	}

	public void TakeDamage(int amount)
	{

	}

	void Death()
	{
		isDead = true;
	}
}
