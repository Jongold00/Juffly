using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InGameUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas currTab;
    [SerializeField]
    private Canvas[] allTabs;
    void Start()
    {
        
    }
    
    public void OpenTab(int i)
    {
        if (currTab && currTab.GetComponent<Tab>().tabName == allTabs[i].GetComponent<Tab>().tabName) // hitting button for currently active tab
        {
            currTab.gameObject.SetActive(false);
            currTab = null;
            return;
        }

        Canvas open = allTabs[i];
        if (currTab != null)
        {
            currTab.gameObject.SetActive(false);
        }
        currTab = open;
        currTab.gameObject.SetActive(true);
    }
}
