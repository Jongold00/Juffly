using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookManager : MonoBehaviour
{
    private static SpellbookManager _instance;
    [SerializeField]
    List<AbilityFactory> availableSpells;
    ActionBarManager actionBar;

    public static SpellbookManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<SpellbookManager>();
        }

        return _instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        actionBar = FindObjectOfType<ActionBarManager>();
    }

    public void SelectAbility(int ind)
    {

    }

    public int LoadAbilityIntoBook(AbilityFactory spell) // returns the index of the loaded ability
    {
        availableSpells.Add(spell);
        return availableSpells.Count - 1;
    }



}