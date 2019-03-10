using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMaker : MonoBehaviour
{
    public GameObject cellprefab;
    public bool isEnable = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        if (!isEnable)
        {
            return;
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject curcell = Instantiate(cellprefab, this.transform);
                curcell.name = "Cell(" + j + "," + i + ")";
            }
        }
    }
}
