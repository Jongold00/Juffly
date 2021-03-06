using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private static AbilityManager _instance;
    public AbilityFactory[] abilityArray = new AbilityFactory[5];
    [SerializeField]
    private int activeAbility = 0;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private GameObject castPoint;
    [SerializeField]
    private ActionBarManager actionBarManager;

    private float[] cdArray = new float[5]; // holds the cd of on cooldown actions... 

    public void FixedUpdate()
    {
        for (int i = 0; i < cdArray.Length; i++)
        {
            if (cdArray[i] > 0)
            {
                cdArray[i] -= Time.fixedDeltaTime;
                actionBarManager.SetCDText(i, cdArray[i]);
            }

        }
    }

    public static AbilityManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<AbilityManager>();
        }   

        return _instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
       // actionBarManager.HighlightSlot();     // this functionality is in the wrong place, should be a part of item selection, not ability bar

    }

    public void LoadInAbility(AbilityFactory spell, int barIndex)
    {
        abilityArray[barIndex] = spell;
        actionBarManager.SetAbilityLogo(barIndex);

    }



    // Update is called once per frame
    void Update()
    {
        ManageInput();
    }

    void ManageInput()
    {
        if (abilityArray[0] && Input.GetKeyDown(KeyCode.Alpha1) && cdArray[0] <= 0.0f)
        {
            abilityArray[0].Cast(castPoint);
            ActionUsed(0);
        }
        if (abilityArray[1] && Input.GetKeyDown(KeyCode.Alpha2) && cdArray[1] <= 0.0f)
        {
            abilityArray[1].Cast(castPoint);
            ActionUsed(1);
        }
        if (abilityArray[2] && Input.GetKeyDown(KeyCode.Alpha3) && cdArray[2] <= 0.0f)
        {
            abilityArray[2].Cast(castPoint);
            ActionUsed(2);
        }
        if (abilityArray[3] && Input.GetKeyDown(KeyCode.Alpha4) && cdArray[3] <= 0.0f)
        {
            abilityArray[3].Cast(castPoint);
            ActionUsed(3);
        }
        if (abilityArray[4] && Input.GetKeyDown(KeyCode.Alpha5) && cdArray[4] <= 0.0f)
        {
            abilityArray[4].Cast(castPoint);
            ActionUsed(4);
        }



    }

    // COOLDOWN RELATED METHODS
    //
    //
    //
    //


    public void ActionUsed(int ind)
    {
        SetCooldown(ind, abilityArray[ind].GetCooldown());
        actionBarManager.InstantiateCDPrefab(ind);


    }


    private void SetCooldown(int ind, float cd)
    {
        cdArray[ind] = cd;
    }


    // GETTERS AND SETTERS
    public int GetActiveAbility()
    {
        return activeAbility;
    }


}
