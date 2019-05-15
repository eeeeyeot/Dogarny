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

		Debug.Log(particleSystems.Length);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Monster")
		{
			if ((enemy = other.GetComponent<EnemyHealth>()) == null)
			{
				return;
			}

			enemy.TakeDamage(20);

			

			for (int i = 0; i < particleSystems.Length; i++)
			{
				Debug.Log(particleSystems[i].name);
				particleSystems[i].gameObject.SetActive(true);
				particleSystems[i].Play();
			}
		}
	}

}
