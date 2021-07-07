using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private static AbilityManager _instance;
    [SerializeField]
    private AAbility[] abilityArray = new AAbility[1];
    [SerializeField]
    private int activeAbility = 0;
    [SerializeField]
    private Transform playerTransform;

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
    }



    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            abilityArray[activeAbility].Cast(playerTransform);
        }
    }
}
