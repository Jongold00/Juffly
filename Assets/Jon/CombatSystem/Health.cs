using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private bool dead = false;
    public Image  healthbar;

    public void Start()
    {
        InitHealth();
    }
    public void InitHealth()
    {
        health = maxHealth;
    }   

    public void takeDamage(float damage)
    {
        health -= damage;
        dead = CheckDeath();
        healthbar.fillAmount = Mathf.Max(0, (health / maxHealth));
    }

    private bool CheckDeath()
    {
        return health <= 0.0f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            takeDamage(10);
        }
    }
}
