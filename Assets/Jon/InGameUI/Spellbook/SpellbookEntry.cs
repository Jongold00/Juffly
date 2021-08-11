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
    int slotToDropIn;

    [SerializeField]
    private AbilityFactory abilityFactory;

    private SpellbookManager spellbook;
    private ActionBarManager actionBarManager;

    [SerializeField]
    private int indexInBook;



    private void Start()
    {
        spellbook = FindObjectOfType<SpellbookManager>();
        indexInBook = LoadIntoSpellbook();
        actionBarManager = FindObjectOfType<ActionBarManager>();

        startPos = spellbook.CalculatePositionInBook(indexInBook);
        transform.localPosition = startPos;
        gameObject.GetComponent<Image>().sprite = abilityFactory.logo;

    }

    private void Update()
    {
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
            spellbook.SelectAbility(indexInBook, slotToDropIn);
            transform.localPosition = startPos;
        }
        else
        {
            transform.localPosition = startPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ActionBarSlot"))
        {
            onBar = true;
            slotToDropIn = GetSlotNumberHit(collision);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ActionBarSlot"))
        {
            onBar = false;
        }
    }

    int GetSlotNumberHit(Collider2D collision)
    {
        GameObject[] slotArray = actionBarManager.GetSlotArray();
        for (int i = 0; i < slotArray.Length; i++)
        {
            if (slotArray[i].Equals(collision.gameObject))
            {
                return i;
            }
        }
        return -1;
    }



}
