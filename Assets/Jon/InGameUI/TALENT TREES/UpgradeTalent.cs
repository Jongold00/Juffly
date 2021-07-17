using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTalent : Talent
{
    [SerializeField]
    protected float damageModifier;
    [SerializeField]
    protected float cooldownModifier;
    [SerializeField]
    protected float rangeModifier;
    [SerializeField]
    protected float velocityModifier;

    public int spellModID;

    public AbilityFactory test;


    private void Start()
    {
    }
    public void Apply(AbilityFactory modAbility)
    {
        test = modAbility;
        modAbility.damage *= damageModifier * currentRanks;
        modAbility.cooldown *= cooldownModifier * currentRanks;
        modAbility.range *= rangeModifier * currentRanks;
        modAbility.velocity *= velocityModifier * currentRanks;
    }

    public float GetDamageMod()
    {
        return damageModifier;
    }

    public float GetRangeMod()
    {
        return rangeModifier;
    }
    public float GetCooldownMod()
    {
        return cooldownModifier;
    }
    public float GetVelocityMod()
    {
        return velocityModifier;
    }

}
