using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private static AbilityManager _instance;
    public AAbility[] abilityArray = new AAbility[5];
    [SerializeField]
    private int activeAbility = 0;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Transform castPoint;
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



    // Update is called once per frame
    void Update()
    {
        ManageInput();
    }

    void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityArray[0].Cast(castPoint);
            ActionUsed(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilityArray[1].Cast(castPoint);
            ActionUsed(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilityArray[2].Cast(castPoint);
            ActionUsed(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityArray[3].Cast(castPoint);
            ActionUsed(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
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
