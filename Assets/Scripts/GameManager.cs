using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public delegate void Dturn(Turn t);

    public event Dturn OnTurnChange; // 턴이 바뀔때마다 호출되는 이벤트
    private Turn turnp=Turn.A;
    public Turn turn 
    {
        get
        {
            return turnp;
        }
        set
        {
            turnp = value;
            OnTurnChange(value);
        }
    }
    // Start is called before the first frame update
    public delegate void Dint(int sco);
    public Dint[] OnScoreChange = new Dint[2];
    private int pscoreA=0;
    private int pscoreB=0;

    public int scoreA
    {
        get
        {
            return pscoreA;
        }
        set
        {
            if(turn==Turn.A)
            {
                pscoreA = value;                
            }
            OnScoreChange[(int)Turn.A](scoreA);

        }
    }

    public int scoreB
    {
        get
        {
            return pscoreB;
        }
        set
        {
            if(turn==Turn.B)
            {
                pscoreB = value;
            }
            OnScoreChange[(int)Turn.B](scoreB);
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void SwitchTurn()
    {
        if(turn==Turn.A)
        {
            turn = Turn.B;
        }
        else
        {
            turn = Turn.A;
        }
    }

    

    public void PushRequest(int row)
    {
        if(LaneManager.instance.PushBlock(row))
        {
            SwitchTurn();
        }        
    }
     
}
