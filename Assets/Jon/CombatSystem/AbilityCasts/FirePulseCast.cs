using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePulseCast : AbilityCast
{
    private void Update()
    {
        UpdateLifeSpan();
    }

    public void Start()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(castPoint, range, new Vector2(0, 0), 0.0f);
        foreach (RaycastHit2D curr in hits) {
            curr.transform.gameObject.GetComponent<Health>().takeDamage(damage);
        }
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
