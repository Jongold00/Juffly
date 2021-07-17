using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityFactory : MonoBehaviour
{
    [SerializeField]
    private int spellID;

    public float cooldown;
    public Sprite logo;
    public float range;
    public GameObject basePrefab;
    public float damage;
    public float velocity;
    public abstract void Cast(GameObject castPoint);


    public bool PlayerAbilityCollision(GameObject collisionObject)
    {
        return collisionObject.CompareTag("Player");
    }
    public float GetCooldown()
    {
        return cooldown;
    }

    public Sprite GetLogo()
    {
        return logo;
    }


    public bool CheckID(int id)
    {
        return spellID == id;
    }


}
