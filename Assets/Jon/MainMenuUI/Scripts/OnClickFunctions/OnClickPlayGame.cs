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
        onClickFunction = OnClickFunction;
        Register(menuDirector);
    }

    void OnClickFunction()
    {
        SceneManager.LoadScene(1);
    }
    public void Register(MenuDirector menuDir)
    {
        menuDir.RegisterOnClick(index, onClickFunction);
    }
}
