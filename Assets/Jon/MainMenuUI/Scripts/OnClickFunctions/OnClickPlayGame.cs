using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnClickPlayGame : MonoBehaviour
{
    // Start is called before the first frame update
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
        SceneManager.LoadScene(1);
    }

}
