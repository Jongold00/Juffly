using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AAbility : MonoBehaviour
{
    public float cooldown;
    public Image logo;
    public float range;

    public abstract void Cast(Transform playerTransform);

}
