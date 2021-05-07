using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tab : MonoBehaviour
{
    public string tabName;
    public GameObject[] panelsList;

    private GameObject currentPanel;


    public void OpenPanel(int index)
    {
        if (currentPanel)
        {
            currentPanel.SetActive(false);
        }
        panelsList[index].SetActive(true);
        currentPanel = panelsList[index];
    }

    private void OnEnable()
    {
        OpenPanel(0);
    }


}
