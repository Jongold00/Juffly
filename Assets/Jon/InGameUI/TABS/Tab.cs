using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public Canvas tabPrefab;
    public string tabName;


    public void OpenTab()
    {
        tabPrefab.enabled = true;
    }

    public void CloseTab()
    {
        tabPrefab.enabled = false;
    }
}
