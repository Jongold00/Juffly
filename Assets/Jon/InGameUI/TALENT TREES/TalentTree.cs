using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalentTree : MonoBehaviour
{
    public Talent[] talents;    // these indices must match up
    public Button[] buttons;    // index of button = index of corresponding talent
    private SpellbookManager spellbook;
    [SerializeField]
    private TalentIntegrationManager tim;

    
    public int availablePoints = 10;
    void Start()
    {
        tim = FindObjectOfType<TalentIntegrationManager>();
        tim.AddTalentTree(this);
        for (int i = 0; i < talents.Length; i++)
        {
            UpdateTalentText(i);
        }
        DeactivateAll();
        CheckUnlocked();
    }


    // all functionality for upgrading and activating talents

    public void AddPointTo(int index)
    {
        talents[index].Increment();
        availablePoints = Mathf.Max(0, availablePoints - 1);
        UpdateTalentText(index);
        CheckUnlocked();
        CheckAvailability();
        tim.SortTalents();
        tim.ApplyTalents();
    }

    private void CheckUnlocked()
    {
        for (int i = 0; i < talents.Length; i++)
        {
            if (talents[i].IsUnlocked())
            {
                buttons[i].interactable = true;
            }

            if (talents[i].maxRanks == talents[i].currentRanks)
            {
                buttons[i].interactable = false;
            }
        }
    }

    private void CheckAvailability()
    {
        if (availablePoints == 0)
        {
            DeactivateAll();
        }
        else
        {
            CheckUnlocked();
        }
    }
    private void DeactivateAll()
    {
        foreach (Button b in buttons)
        {
            b.interactable = false;
        }
    }
    
    private void UpdateTalentText(int i)
    {
        buttons[i].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = talents[i].currentRanks.ToString() + '/' + talents[i].maxRanks.ToString();
    }


}
