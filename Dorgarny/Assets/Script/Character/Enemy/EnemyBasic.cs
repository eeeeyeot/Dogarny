using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyBasic : MonoBehaviour
{
    

    [Header("Health")]
    public Image healthBar;
    public float startHealth = 100f;
    public float health; //For Test: private => public

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
