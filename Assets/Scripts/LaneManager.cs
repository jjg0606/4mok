using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public static LaneManager instance;

    public Cell[][] cellarr = new Cell[6][];
    private int[] height = new int[6];
    private Queue<int> checkque= new Queue<int>();
    private Queue<int> deleteque = new Queue<int>();
    private GameManager gmi;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gmi = GameManager.instance;
        for(int i=0;i<6;i++)
        {
            cellarr[i] = new Cell[10];
            for(int j=0;j<10;j++)
            {
                cellarr[i][j] = GameObject.Find("Cell(" + i + "," + j + ")").GetComponent<Cell>();
            }
        }

    }

    // Update is called once per frame
    public bool PushBlock(int row)
    {
        int h = height[row];
        if (h >=10)
        {
            return false;
        }
        cellarr[row][h].cur = (int)gmi.turn;
        height[row]++;
        checkque.Enqueue(h);
        CheckBlock();

        return true;
    }

    public void CheckBlock()
    {
        int minh = 10000;
        while(checkque.Count!=0)
        {
            int h = checkque.Dequeue();
            minh = Mathf.Min(h, minh);
            int cur = cellarr[3][h].cur;
            if (cur==-1)
            {
                continue;
            }
            // 한줄빙고가 되는 지 확인
            int[] check = new int[6];
            check[3] = 1;
            int cnt = 1;
            int next = 4;
            while (next < 6&&cellarr[next][h].cur==cur)
            {
                check[next] = 1;
                next++;
                cnt++;
            }
            next = 2;
            while (next >= 0 && cellarr[next][h].cur == cur)
            {
                check[next] = 1;
                next--;
                cnt++;
            }
            // 안되면 리턴
            if(cnt<4)
            {
                continue;
            }
            // 점수 추가
            if(cur==(int)Turn.A)
            {
                gmi.scoreA += cnt;
            }
            else
            {
                gmi.scoreB += cnt;
            }

            for(int j=0;j<6;j++)
            {
                if(check[j]==1)
                {
                    cellarr[j][h].cur = -1;
                    height[j]--;
                }
            }
            deleteque.Enqueue(h);
        }
        if(deleteque.Count!=0)
        {
            DeleteBlock();
            for(int i=minh;i<10;i++)
            {
                checkque.Enqueue(i);
            }
            CheckBlock();
        }
        

    }
        
    public void DeleteBlock()
    {        
        while(deleteque.Count!=0)
        {
            int h = deleteque.Dequeue();
            for(int r=0;r<6;r++)
            {
                if(cellarr[r][h].cur!=-1)
                {
                    continue;
                }
                for(int c=h+1;c<10;c++)
                {                    
                    cellarr[r][c - 1].cur = cellarr[r][c].cur;
                    if (cellarr[r][c].cur == -1)
                    {
                        break;
                    }
                }
            }
        }
    }


}
