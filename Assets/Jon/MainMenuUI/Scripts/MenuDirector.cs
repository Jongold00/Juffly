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
    static MenuDirector _instance;
    public GameObject[] tabs;

    public static MenuDirector GetInstance()
    {
        if (_instance == null)
        {
            _instance = GameObject.FindObjectOfType<MenuDirector>();
        }

        return _instance;
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


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

    public void LoadTab(int index)
    {
        foreach (GameObject curr in tabs)
        {
            curr.SetActive(false);
        }
        tabs[index].SetActive(true);
    }

}
