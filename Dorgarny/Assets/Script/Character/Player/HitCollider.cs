using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
	public EnemyStats enemy;
	public PlayerStats player;
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
		if ((enemy = other.GetComponent<EnemyStats>()) == null)
			return;

		if (other.gameObject.tag == "Enemy")
		{
			enemy.TakeDamage(player.GetDamage());
			Debug.Log("Damage to mob");
			for (int i = 0; i < particleSystems.Length; i++)
			{
				particleSystems[i].gameObject.SetActive(true);
				particleSystems[i].Play();
			}
		}
	}

}
