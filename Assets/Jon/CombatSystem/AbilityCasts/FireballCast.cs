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

    float timeElapsed = 0.0f;

    public void init(float cd, float rng, float dam, Sprite spt, Vector2 dir, float vel)
    {
        cooldown = cd;
        range = rng;
        damage = dam;
        sprite = spt;
        direction = dir;
        velocity = vel;
        print(direction);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
    }



    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 5.0)
        {
            Destroy(gameObject);
        }
    }


}
