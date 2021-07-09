using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityFactory : MonoBehaviour
{
    public float cooldown;
    public Sprite logo;
    public float range;
    public GameObject basePrefab;

    public abstract void Cast(GameObject castPoint);
    public float GetCooldown()
    {
        return cooldown;
    }

}
