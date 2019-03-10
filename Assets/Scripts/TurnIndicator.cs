using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnIndicator : MonoBehaviour
{
    private Image image;
    public Sprite turnA;
    public Sprite turnB;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.OnTurnChange += this.ChangeIndicator;
        image = GetComponent<Image>();
    }

    void ChangeIndicator(Turn turn)
    {
        if(turn==Turn.A)
        {
            image.sprite = turnA;
        }
        else
        {
            image.sprite = turnB;
        }
    }
}
