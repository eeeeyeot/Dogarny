using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
public class EnemyHealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
=======
=======
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
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
		if(currentHealth <= 0)
		{
			gameObject.SetActive(false);
		}
	}

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
	}

	void Death()
	{
		isDead = true;
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
=======
>>>>>>> parent of 768d38e... 2019-05-19
	}
}
