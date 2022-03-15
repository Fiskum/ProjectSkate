using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public AudioSource Music;

    public void PauseMusic()
    {
        Music.Pause();
        Manager_Game.GetManager().PauseGame();
    }

    public void UnPauseMusic()
    {
        Music.Play();
        Manager_Game.GetManager().UnPauseGame();
    }
}
