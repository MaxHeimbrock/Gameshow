using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    public GameObject pointBox;

    public int pointsToWin = 0;
    public int pointsWon = 0;
    private GameObject[] checkboxArray;
    private GameObject[] pointsWonArray;

    bool locked = false;

    QuizManager currentRound;
    
    public void DestroyCheckboxes()
    {
        if (checkboxArray == null)
        {
            return;
        }

        for (int i = 0; i < checkboxArray.Length; i++)
        {
            Destroy(checkboxArray[i]);
        }
    }

    public void Init(QuizManager currentRound, int pointsToWin)
    {
        this.currentRound = currentRound;

        DestroyCheckboxes();

        locked = false;

        this.pointsToWin = pointsToWin;
        pointsWon = 0;

        checkboxArray = new GameObject[pointsToWin];
        pointsWonArray = new GameObject[pointsToWin];

        for (int i = 0; i < pointsToWin; i++)
        {
            checkboxArray[i] = Instantiate(pointBox);
            checkboxArray[i].transform.SetParent(this.transform);
        }
    }

    public void WinPoint()
    {
        if (locked == true)
        {
            return;
        }

        if (checkboxArray == null)
        {
            return;
        }

        checkboxArray[pointsWon].transform.GetChild(0).gameObject.SetActive(true);
        
        pointsWon++;

        if (pointsWon == pointsToWin)
        {
            locked = true;
            currentRound.SetGameWon(true);
        }
    }

    public void RevokePoint()
    {
        if (pointsWon == 0)
        {
            return;
        }

        pointsWon--;

        checkboxArray[pointsWon].transform.GetChild(0).gameObject.SetActive(false);

        if (locked == true)
        {
            locked = false;
            currentRound.SetGameWon(false);
        }
    }
}
