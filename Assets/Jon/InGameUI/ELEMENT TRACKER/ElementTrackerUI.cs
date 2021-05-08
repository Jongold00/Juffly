using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementTrackerUI : MonoBehaviour
{
    public ElementStat[] stats;

    void Start()
    {

    }

    public void UpdateStat(int value)
    {
        stats[0].AddToStat(value);
    }
}
