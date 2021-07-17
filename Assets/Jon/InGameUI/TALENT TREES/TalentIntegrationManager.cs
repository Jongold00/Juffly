using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentIntegrationManager : MonoBehaviour
{
    private static TalentIntegrationManager _instance;

    [SerializeField]
    private List<TalentTree> talentTrees;

    [SerializeField]
    private List<UpgradeTalent> activeUpgradeTalents;

    [SerializeField]
    private SpellbookManager spellbook;
    public static TalentIntegrationManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<TalentIntegrationManager>();
        }

        return _instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        spellbook = FindObjectOfType<SpellbookManager>();
    }

    public void AddTalentTree(TalentTree tree)
    {
        talentTrees.Add(tree);
    }

    public void SortTalents()
    {
        foreach (TalentTree tree in talentTrees)
        {
            foreach (Talent talent in tree.talents)
            {
                if (talent is UpgradeTalent && talent.currentRanks == 1)
                {
                    activeUpgradeTalents.Add(talent as UpgradeTalent);
                }
            }
        }
    }

    public void ApplyTalents()
    {
        foreach (UpgradeTalent curr in activeUpgradeTalents)
        {
            curr.Apply(spellbook.GetAbilityByID(curr.spellModID));
        }
    }


}
