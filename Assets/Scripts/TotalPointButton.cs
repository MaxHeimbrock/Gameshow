using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TotalPointButton : MonoBehaviour
{
    public int number;

    private Image image;
    private Score teamScore;
    private TextMeshProUGUI pointText;

    private bool clicked = false;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        teamScore = GetComponentInParent<Score>();
        pointText = GetComponentInChildren<TextMeshProUGUI>();

        // All games give one point now
        //pointText.SetText(number.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Clicked()
    {
        clicked = !clicked;

        if (clicked)
        {
            GameWon();
        }
        else if (!clicked)
        {
            Revert();
        }
    }

    private void GameWon()
    {
        teamScore.AddPointsToTeamScore(1);
        image.color = Color.white;
    }

    private void Revert()
    {
        teamScore.RemovePointsToTeamScore(1);
        image.color = Color.black;
    }
}
