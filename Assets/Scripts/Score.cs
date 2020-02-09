using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int teamScore = 0;

    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.SetText(teamScore.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPointsToTeamScore(int points)
    {
        teamScore += points;

        scoreText.SetText(teamScore.ToString());
    }

    public void RemovePointsToTeamScore(int points)
    {
        teamScore -= points;
        scoreText.SetText(teamScore.ToString());
    }
}
