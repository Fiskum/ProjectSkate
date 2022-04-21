using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public AudioSource music;
    public AudioSource SFX;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        music.mute = muted;
    }
    private bool muted = false;
    public void OnClick_Music()
    {
        if(muted == false)
        {
            muted = true;
            music.mute = true;
        }
        else
        {
            muted = false;
            music.mute = false;
        }

        Save();
    }

    public void OnClick_SFX()
    {
        if (muted == false)
        {
            muted = true;
            SFX.mute = true;
        }
        else
        {
            muted = false;
            SFX.mute = false;
        }

        Save();
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }


    public void OnClick_Account()
    {
        
    }
    public void OnClick_AutoStart()
    {
        
    }


}
