using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public AudioSource Music;

    public void PauseMusic()
    {
        Music.Pause();
    }

    public void UnPauseMusic()
    {
        Music.Play();
    }
}
