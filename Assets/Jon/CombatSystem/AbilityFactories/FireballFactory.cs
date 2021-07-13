using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballFactory : AbilityFactory
{

    private GameObject instance;
    public override void Cast(GameObject castPoint)
    {
        CastPointMouseFollow cpScript = castPoint.GetComponent<CastPointMouseFollow>();
        instance = Instantiate(basePrefab, castPoint.transform.position, new Quaternion(0,0,0,0));
        FireballCast castScript = instance.GetComponent<FireballCast>();
        castScript.Init(cooldown, range, damage, logo, cpScript.dir, velocity, castPoint.transform.position, 5.0f);
    }

}
