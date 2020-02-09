using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource gameSound;
    public AudioSource soundEffects;

    public AudioSource roundIntroSound;
    public AudioSource bigIntroSound;
    public AudioClip airhorn;
    public AudioClip laughter;
    public AudioClip trombone;

    public void PlayRoundIntro()
    {
        roundIntroSound.Play();
    }

    public void PlayBigIntro()
    {
        bigIntroSound.Play();
    }

    public void PlayAirhorn()
    {
        PlaySoundEffect(airhorn);
    }
    public void PlayLaughter()
    {
        PlaySoundEffect(laughter);
    }
    public void PlayTrombone()
    {
        PlaySoundEffect(trombone);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayAirhorn();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayLaughter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlayTrombone();
        }
    }

    public void PlayGameSound(AudioClip clip)
    {
        gameSound.Stop();
        gameSound.clip = clip;
        gameSound.Play();
    }

    public void StopGameSound()
    {
        gameSound.Stop();
    }

    private void PlaySoundEffect(AudioClip clip)
    {
        soundEffects.Stop();
        soundEffects.clip = clip;
        soundEffects.Play();
    }
}
