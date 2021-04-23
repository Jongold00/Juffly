using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;


public class MenuDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainCanvas;

    [SerializeField]
    private Button[] onClicks;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RegisterOnClick(int ind, UnityAction func)
    {
        Button curr = onClicks[ind];
        curr.onClick.AddListener(func);
    }

}
