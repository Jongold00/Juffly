using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talent : MonoBehaviour
{
    public int maxRanks;
    public int currentRanks;
    public Talent[] prereqs;

    public void Increment()
    {
        currentRanks++;
    }

    public bool IsUnlocked()
    {
        foreach (Talent t in prereqs)
        {
            if (t.currentRanks < t.maxRanks)
            {
                return false;
            }
        }
        return true;
    }
}
