using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AAbility : MonoBehaviour
{
    public float cooldown;
    public Image logo;

    public abstract void Cast(Transform playerTransform);

}
