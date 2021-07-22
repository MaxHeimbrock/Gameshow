using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameState {wait, intro, explanationTeams, explanationPoints, breakBeforeRound, round, commercialBreak}
    [SerializeField] private GameState currentState;

    public ParticleSystem confetti;
    public GameObject intro;
    public Animator curtainsAnimator;

    public GameObject commercialBreak;
    GameObject commercialBreakObject;

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
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            if (roundFinished == true)
            {
                NextState();
            }
        }        
    }

    private void StartIntro()
    {
        SoundManager.Instance.PlayBigIntro();
        curtainsAnimator.SetTrigger("OpenCurtains");
        confetti.Play();
    }

    private void StartExplanationNames()
    {
        confetti.Stop();
        Destroy(intro);
        TeamTags.Instance.ComeIn();
    }

    private void StartExplanationPoints()
    {
        TotalPoints.Instance.ComeIn();
        SoundManager.Instance.MakeSwoosh();
    }

    private void HidePoints()
    {
        TotalPoints.Instance.GoOut();
        SoundManager.Instance.MakeSwoosh();
        TeamTags.Instance.GoOut();
    }

    private void StartRound()
    {
        currentRound = Instantiate(rounds[currentRoundNumber]);
        currentRound.transform.SetParent(this.transform);
        currentRound.SetTag(currentRoundNumber + 1);
        roundFinished = false;
    }

    private void FinishedRound()
    {
        Destroy(currentRound.gameObject);
        currentRoundNumber++;
        roundFinished = true;
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
                HidePoints();
                if (currentRoundNumber == 3)
                {
                    StartCommercialBreak();
                    currentState = GameState.commercialBreak;
                }
                else
                    currentState++;
                break;
            case GameState.breakBeforeRound:
                StartRound();
                currentState++;
                break;
            case GameState.round:
                FinishedRound();
                currentState = GameState.explanationTeams;
                break;


            case GameState.commercialBreak:
                StopCommercialBreak();
                currentState = GameState.breakBeforeRound;
                break;
        }
    }

    private void StopCommercialBreak()
    {
        Destroy(commercialBreakObject);
    }

    private void StartCommercialBreak()
    {
        commercialBreakObject = Instantiate(commercialBreak);        
    }
}
