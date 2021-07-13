using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : AbilityCast
{


    private void Update()
    {
        UpdateLifeSpan();
        rb.velocity = transform.up * velocity * -1;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            return;
        }
        collision.gameObject.GetComponent<Health>().takeDamage(damage);
        Destroy(gameObject);
    }


}
