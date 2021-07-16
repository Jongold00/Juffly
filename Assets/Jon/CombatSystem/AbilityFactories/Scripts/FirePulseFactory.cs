using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePulseFactory : AbilityFactory
{
    private GameObject instance;

    public override void Cast(GameObject castPoint)
    {
        instance = Instantiate(basePrefab, castPoint.transform.position, new Quaternion(0, 0, 0, 0));
        FirePulseCast castScript = instance.GetComponent<FirePulseCast>();
        castScript.Init(cooldown, range, damage, logo, castPoint.transform.position, 0.25f);

    }
}
