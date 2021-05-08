using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElementStat : MonoBehaviour
{
    [SerializeField]
    private float stat;
    [SerializeField]
    private int level;
    [SerializeField]
    private TextMeshProUGUI statLabel;
    [SerializeField]
    private RectTransform statBar;

    private Vector2 maxBarScale = new Vector2(-350, 6);
    private Vector2 minBarScale = new Vector2(-50, 0.01f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddToStat(int add)
    {
        stat += add;
        CalculateLevel();
        ScaleStatBar();
    }

    public float GetStat()
    {
        return stat;
    }

    public int GetLevel()
    {
        return level;
    }

    public float GetNextCutoff()
    {
        return 6000 - stat;        // placeholder nonsense
    }

    private void ScaleStatBar()
    {
        float percentageIn = (stat / 6000);
        print("percentage in " + percentageIn.ToString());
        statBar.localScale = new Vector3(1f, 0.01f + ((maxBarScale.y - minBarScale.y) * percentageIn), 1f);
        statBar.localPosition = new Vector3(0, -50 + ((maxBarScale.x - minBarScale.x) * percentageIn), 0);
    }

    public void CalculateLevel()
    {
        print("remaining xp = " + GetNextCutoff().ToString());
        if (GetNextCutoff() <= 0)
        {
            stat -= 6000; // placeholder nonsense
            level++;
        }
    }

}
