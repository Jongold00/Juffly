using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellbookManager : MonoBehaviour
{
    public const int spellsPerPage = 8;

    private static SpellbookManager _instance;
    [SerializeField]
    List<AbilityFactory> availableSpells;
    [SerializeField]
    Tab spellbookTab;
    ActionBarManager actionBar;
    AbilityManager abilityManager;

    public GameObject slotPrefab;

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
        abilityManager = FindObjectOfType<AbilityManager>();
        PlaceSlotsOnPage();
    }

    public void SelectAbility(int bookIndex, int barIndex)
    {
        abilityManager.LoadInAbility(availableSpells[bookIndex], barIndex);
    }

    public int LoadAbilityIntoBook(AbilityFactory spell) // returns the index of the loaded ability
    {
        availableSpells.Add(spell);
        return availableSpells.Count - 1;
    }

    public AbilityFactory GetAbilityByID(int id)
    {
        foreach (AbilityFactory curr in availableSpells)
        {
            if (curr.CheckID(id))
            {
                return curr;
            }
        }
        return null;
    }


    public Vector2 CalculatePositionInBook(int spellIndex) // returns the local position of a factory prefab in the book page
    {


        Vector2 ret = Vector2.zero;
        var ind = spellIndex % spellsPerPage;
        ret.x = ind % 2 == 0 ? -400 : -200;
        switch(ind / 2)
        {
            case 0:
                {
                    ret.y = 200;
                    break;
                }

            case 1:
                {
                    ret.y = 67;
                    break;
                }

            case 2:
                {
                    ret.y = -67;
                    break;
                }

            case 3:
                {
                    ret.y = -200;
                    break;
                }
        }
        
        return ret;
    }


    void PlaceSlotsOnPage()
    {
        foreach (GameObject page in spellbookTab.panelsList)
        {
            for (int i = 0; i < spellsPerPage; i++)
            {
                GameObject currentInst = Instantiate(slotPrefab, page.transform);
                currentInst.transform.localPosition = CalculatePositionInBook(i);
            }
        }
    }
}
