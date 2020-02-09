using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public string roundName;
    public int roundNumber;
    public int pointsToWin;

    public GameObject roundTagPrefab;
    private GameObject roundTagObject;
    private TextMeshProUGUI roundText;
    private PointUI[] pointUIs;

    bool gameWon = false;

    StateMachine gameStateMachine;
    int currentRound = 0;

    public Round[] rounds;

    public enum RoundState {intro, showPoints, game}
    RoundState currentState;

    public void Update()
    {
        #region userinput

        if (Input.GetKeyDown(KeyCode.A))
        {
            pointUIs[0].WinPoint();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            pointUIs[0].RevokePoint();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            pointUIs[1].WinPoint();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            pointUIs[1].RevokePoint();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextState();
        }

        gameStateMachine.Update();

        #endregion;
    }

    public void Start()
    {
        currentState = RoundState.intro;
        SoundManager.Instance.PlayRoundIntro();

        roundTagObject = Instantiate(roundTagPrefab);
        roundTagObject.transform.SetParent(this.transform);
        roundText = roundTagObject.GetComponentInChildren<TextMeshProUGUI>();
        roundText.SetText("Spiel " + roundNumber + "\n" + roundName);

        pointUIs = FindObjectsOfType<PointUI>();

        gameStateMachine = new StateMachine();
        rounds = GetComponentsInChildren<Round>();
    }

    public void ShowPoints()
    {
        Destroy(roundTagObject);

        TeamTags.Instance.ComeIn();

        SoundManager.Instance.StopGameSound();
        foreach (PointUI pointUI in pointUIs)
        {
            pointUI.Init(this, pointsToWin);
        }
    }

    private void NextState()
    {
        switch (currentState)
        {
            case RoundState.intro:
                ShowPoints();
                currentState++;
                break;
            case RoundState.showPoints:
                gameStateMachine.NextState(rounds[0]);
                currentState++;
                break;
            case RoundState.game:
                if (gameWon || (currentRound + 1 == rounds.Length))
                {
                    gameStateMachine.GetCurrentState().Exit();
                    FinishRound();
                }
                else
                {
                    gameStateMachine.NextState(rounds[++currentRound]);
                }
                break;
        }
    }

    public void SetGameWon(bool gameWon)
    {
        this.gameWon = gameWon;
    }

    private void FinishRound()
    {
        foreach (PointUI pointUI in pointUIs)
        {
            pointUI.DestroyCheckboxes();
        }
        GameManager.Instance.NextState();
    }
}
