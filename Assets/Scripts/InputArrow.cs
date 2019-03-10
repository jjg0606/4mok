using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputArrow : MonoBehaviour
{
    public int row;
    
    public void OnClick()
    {
        GameManager.instance.PushRequest(row);
    }
}
