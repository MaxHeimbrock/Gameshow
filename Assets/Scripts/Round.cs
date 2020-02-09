using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Round : MonoBehaviour, IState
{
    public AudioClip audioClip;
    public GameObject image;
    private GameObject imageInstance;
    public GameObject solutionTag;
    private GameObject solutionTagInstance;
    public string solutionText;

    public void Enter()
    {

        if (audioClip != null)
        {
            SoundManager.Instance.PlayGameSound(audioClip);
        }
        if (image != null)
        {
            imageInstance = Instantiate(image);
            imageInstance.transform.SetParent(transform);
        }
        if (solutionTag != null)
        {
            solutionTagInstance = Instantiate(solutionTag);
            solutionTagInstance.transform.SetParent(transform);

            TextMeshProUGUI roundText = solutionTagInstance.GetComponentInChildren<TextMeshProUGUI>();
            roundText.SetText(solutionText);
        }
    }

    public void Execute()
    {

    }

    public void Exit()
    {
        SoundManager.Instance.StopGameSound();
        Destroy(imageInstance);
        Destroy(solutionTagInstance);
    }
}
