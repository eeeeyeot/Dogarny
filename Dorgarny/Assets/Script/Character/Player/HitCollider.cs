using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
	EnemyHealth enemy;
	public GameObject particleGameObject;
	ParticleSystem[] particleSystems;

	private void Start()
	{
		particleSystems = new ParticleSystem[particleGameObject.transform.childCount];
		particleSystems = particleGameObject.GetComponentsInChildren<ParticleSystem>();
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("HitSomething : " + other.name);
		if (other.gameObject.tag == "Monster")
		{
			
			enemy = other.GetComponent<EnemyHealth>();

			enemy.TakeDamage(20);

			

			for (int i = 0; i < particleSystems.Length; i++)
			{
				particleSystems[i].gameObject.SetActive(true);
				particleSystems[i].Play();
			}
		}
	}

}
