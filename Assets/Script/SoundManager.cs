using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource EffectSource;

    public float LowPitchRange = 0.95f;
    public float HighPichRange = 1.05f;

    public static SoundManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip, bool loop = false)
    {
        EffectSource.loop = loop;
        EffectSource.clip = clip;
        EffectSource.Play();
    }

    public void Pause()
    {
        EffectSource.Pause();
    }


    public void Stop()
    {
        EffectSource.Stop();
    }

    public void RandomSoundEffect(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPichRange);

        EffectSource.pitch = randomPitch;
        EffectSource.clip = clips[randomIndex];
        EffectSource.Play();
    }
}
