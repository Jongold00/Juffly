using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityCast : MonoBehaviour
{

    protected float cooldown;
    protected float range;
    protected float damage;
    protected float lifeSpan;

    protected Vector3 direction;
    protected float velocity;
    protected Vector3 castPoint;

    protected Sprite sprite;

    [SerializeField]
    protected Rigidbody2D rb;

    float timeElapsed = 0.0f;

    // init for projectile abilities
    public void Init(float cd, float rng, float dam, Sprite spt, Vector2 dir, float vel, Vector3 cp, float ls)
    {
        cooldown = cd;
        range = rng;
        damage = dam;
        sprite = spt;
        direction = dir;
        velocity = vel;
        castPoint = cp;
        lifeSpan = ls;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
    }

    // init for playerPoint abilities
    public void Init(float cd, float rad, float dam, Sprite spt, Vector3 playerPoint, float ls)
    {
        cooldown = cd;
        range = rad;
        damage = dam;
        sprite = spt;
        lifeSpan = ls;
        castPoint = playerPoint;
    }

    public void UpdateLifeSpan()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > lifeSpan)
        {
            Destroy(gameObject);
        }
    }


}
