using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState {wait, intro, explanationTeams, explanationPoints, round, points}
    [SerializeField] private GameState currentState;

    public QuizManager[] rounds;

    QuizManager currentRound;
    public int currentRoundNumber;

    bool roundFinished = true;

    public GameObject points;
    public GameObject[] teamTags;

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameState.wait;
        currentRoundNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (roundFinished == true)
            {
                NextState();
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
           FinishedRound();
           currentState++;
        }
    }

    private void StartIntro()
    {
        SoundManager.Instance.PlayBigIntro();
    }

    private void StartExplanationNames()
    {
        TeamTags.Instance.ComeIn();
    }

    private void StartExplanationPoints()
    {
        TotalPoints.Instance.ComeIn();
    }

    private void StartRound()
    {
        TotalPoints.Instance.GoOut();
        currentRound = Instantiate(rounds[currentRoundNumber]);
        currentRound.transform.SetParent(this.transform);
        roundFinished = false;

        TeamTags.Instance.GoOut();

        /*
        foreach (GameObject teamTag in teamTags)
        {
            teamTag.SetActive(false);
        }
        */
    }

    private void FinishedRound()
    {
        Destroy(currentRound.gameObject);
        currentRoundNumber++;
        roundFinished = true;
        TotalPoints.Instance.ComeIn();
    }

    public void NextState()
    {
        switch (currentState)
        {
            case GameState.wait:
                StartIntro();
                currentState++;
                break;
            case GameState.intro:
                StartExplanationNames();
                currentState++;
                break;
            case GameState.explanationTeams:
                StartExplanationPoints();
                currentState++;                
                break;
            case GameState.explanationPoints:
                StartRound();
                currentState++;
                break;
            case GameState.round:
                FinishedRound();
                currentState++;
                break;
            case GameState.points:
                currentState = GameState.explanationTeams;
                break;
        }
    }
}
