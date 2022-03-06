using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public AudioSource music;
    public void OnClick_Play_Level1()
    {
        Time.timeScale = 1;
        music.Play();
    }
    public void OnClick_Back()
    {
       
    }
}
