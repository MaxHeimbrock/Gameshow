using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzer : Singleton<Buzzer>
{
    public AudioClip timerStart;
    public AudioClip timerTicking;
    public AudioClip timerEnd;

    public bool locked = false;

    private Color initialBackgroundColor;

    public Color teamOneColor;
    public Color teamTwoColor;

    // Start is called before the first frame update
    void Start()
    {
        initialBackgroundColor = Camera.main.backgroundColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                locked = true;
                TeamOneAnswers();
            }

            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                locked = true;
                TeamTwoAnswers();
            }
        }        
    }

    public void SetBuzzerLock(bool locked)
    {
        this.locked = locked;
    }

    void TeamOneAnswers()
    {
        StartCoroutine(StartTimer(teamOneColor));
    }
    void TeamTwoAnswers()
    {
        StartCoroutine(StartTimer(teamTwoColor));
    }

    private IEnumerator StartTimer(Color teamColor)
    {
        SoundManager.Instance.PlayGameSound(timerStart);
        yield return new WaitForSeconds(0.1f);
        Camera.main.backgroundColor = teamColor;
        yield return new WaitForSeconds(0.4f);
        SoundManager.Instance.PlayGameSound(timerTicking);
        yield return new WaitForSeconds(5);
        SoundManager.Instance.PlayGameSound(timerEnd);
        yield return new WaitForSeconds(1.5f);
        SoundManager.Instance.StopGameSound();
        locked = false;
        Camera.main.backgroundColor = initialBackgroundColor;
    }
}
