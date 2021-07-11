using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCast : MonoBehaviour
{
    float cooldown;
    float range;
    float damage;
    Sprite sprite;
    Vector3 direction;
    float velocity;
    GameObject castPoint;

    [SerializeField]
    Rigidbody2D rb;

    float timeElapsed = 0.0f;

    public void init(float cd, float rng, float dam, Sprite spt, Vector2 dir, float vel, GameObject cp)
    {
        cooldown = cd;
        range = rng;
        damage = dam;
        sprite = spt;
        direction = dir;
        velocity = vel;
        castPoint = cp;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
    }



    private void Update()
    {
        timeElapsed += Time.deltaTime;
        rb.velocity = transform.up * velocity * -1;
        if (timeElapsed > 5.0)
        {
            Destroy(gameObject);
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
