using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class OnClickLoadTab : MonoBehaviour
{
    public int index;
    private UnityAction onClickFunction;
    public MenuDirector menuDirector;
    void Start()
    {
        menuDirector = FindObjectOfType<MenuDirector>();
        onClickFunction = OnClickFunction;
        menuDirector.RegisterOnClick(index, onClickFunction);
    }

    void OnClickFunction()
    {
        menuDirector.LoadTab(index - 1);
    }
}
