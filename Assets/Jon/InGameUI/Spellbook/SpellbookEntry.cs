using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SpellbookEntry : MonoBehaviour
{

    bool dragging;
    bool onBar;

    Vector2 slotPos;
    Vector2 startPos;

    [SerializeField]
    private AbilityFactory abilityFactory;

    private SpellbookManager spellbook;
    [SerializeField]
    private int indexInBook;



    private void Start()
    {
        startPos = transform.position;
        spellbook = FindObjectOfType<SpellbookManager>();
        indexInBook = LoadIntoSpellbook();
    }

    private void Update()
    {
        print(onBar);
        if (dragging)
        {
            transform.position = Input.mousePosition;
        }
    }

    int LoadIntoSpellbook()
    {
        return spellbook.LoadAbilityIntoBook(abilityFactory);
    }



    // CODE FOR DRAGGING INTO ACTIONBAR

    public void StartDrag()
    {
        dragging = true;
    }

    public void StopDrag()
    {
        dragging = false;
        if (onBar)
        {
            transform.position = slotPos;
        }
        else
        {
            transform.position = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hello");
        if (collision.CompareTag("ActionBarSlot"))
        {
            onBar = true;
            slotPos = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ActionBarSlot"))
        {
            onBar = false;

        }
    }



}
