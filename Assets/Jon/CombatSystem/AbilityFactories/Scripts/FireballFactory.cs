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


        float tempcd = cooldown;
        float tempdamage = damage;
        float temprange = range;
        float tempvelocity = velocity;

        foreach (UpgradeTalent curr in talentMods)
        {
            tempcd = cooldown * curr.GetCooldownMod();
            tempdamage = damage * curr.GetDamageMod();
            temprange = range * curr.GetRangeMod();
            tempvelocity = velocity * curr.GetVelocityMod();
        }




        castScript.Init(tempcd, temprange, tempdamage, logo, cpScript.dir, tempvelocity, castPoint.transform.position, 5.0f);

    }

}
