using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Turn player;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        GameManager.instance.OnScoreChange[(int)player] += this.UpdateScore;
        text.text = "0";
    }

    void UpdateScore(int score)
    {
        text.text = score.ToString();
    }
}
