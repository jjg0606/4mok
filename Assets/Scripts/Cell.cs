using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    // Start is called before the first frame update
    private Image image;
    private int curC;
    public int cur
    {
        get
        {
            return curC;
        }
        set
        {
            curC = value;
            setColor(value);
        }
    }
    private void OnEnable()
    {
        image = GetComponent<Image>();
        cur = -1;
    }
    
    void setColor(int t)
    {
        switch(t)
        {
            case (int)Turn.A:
                image.color = Color.red;
                break;
            case (int)Turn.B:
                image.color = Color.blue;
                break;
            default:
                image.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                break;
        }
    }
}
