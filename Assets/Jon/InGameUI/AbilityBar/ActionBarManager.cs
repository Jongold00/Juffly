using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionBarManager : MonoBehaviour       // this class is purely UI, only does visuals for AbilityManager class
{
    private static ActionBarManager _instance;
    [SerializeField]
    private AbilityManager abilityManager;
    
    
    [SerializeField]
    private Sprite highlightedSlotSprite;
    [SerializeField]
    private Sprite slotSprite;
    [SerializeField]
    private GameObject cooldownPrefab;

    [SerializeField]
    private GameObject[] slotArray;
    private TextMeshProUGUI[] textObjects = new TextMeshProUGUI[5];

    public static ActionBarManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<ActionBarManager>();
        }

        return _instance;
    }




    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetCDText(int ind, float cd)
    {
        textObjects[ind].text = Mathf.Ceil(cd).ToString() + "s";
        CheckOffCD(ind, cd);
    }

    private void CheckOffCD(int ind, float cd)
    {
        if (cd <= 0)
        {
            Destroy(textObjects[ind].transform.parent.gameObject);      // destroys the whole CD prefab
            textObjects[ind] = null;

        }
    }


    public void InstantiateCDPrefab(int ind)
    {
        GameObject currentSlot = slotArray[ind];
        GameObject newInstance = Instantiate(cooldownPrefab, currentSlot.transform.position, new Quaternion(0, 0, 0, 0), currentSlot.transform);
        textObjects[ind] = newInstance.GetComponentInChildren<TextMeshProUGUI>();
    }


    public void HighlightSlot()         // this functionality is in the wrong place, should be a part of item selection, not ability bar
    {
        foreach (GameObject curr in slotArray)
        {
            curr.GetComponent<Image>().sprite = slotSprite;
        }
        slotArray[abilityManager.GetActiveAbility()].GetComponent<Image>().sprite = highlightedSlotSprite;        
    } 
} 
