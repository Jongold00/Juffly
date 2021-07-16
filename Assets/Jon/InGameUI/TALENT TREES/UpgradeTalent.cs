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

    [SerializeField]
    protected int spellModID;
    protected AbilityFactory modAbility;


    private void Start()
    {
        modAbility = FindObjectOfType<SpellbookManager>().GetAbilityByID(spellModID);
    }
    public override void Apply()
    {
        modAbility.ApplyUpgradeTalent(this);
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
