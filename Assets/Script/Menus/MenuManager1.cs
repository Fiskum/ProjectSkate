using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager1 : MonoBehaviour
{
    [Header("Menus")]
    public GameObject UI_MainMenu;
    public GameObject UI_ChapterSelect;
    public GameObject UI_LevelSelect;
    public GameObject UI_ShopCharacters;
    public GameObject UI_ShopParticels;
    public GameObject UI_IngamePurchases;
    public GameObject UI_LeaderBoard;
    public GameObject UI_Options;
    public GameObject UI_IngameOptions;
    public GameObject UI_HTP;

    [Header("Others")]
    public AudioSource music;
    public AudioClip clickClip;

    public void GoToMainMenu()
    {
        UI_MainMenu.SetActive(true);
        Manager_Game.GetManager().PauseGame();
        music.Pause();
    }

    public void GoToChapterSelect()
    {
        UI_ChapterSelect.SetActive(true);
    }

    public void GoToLevelSelect()
    {
        UI_LevelSelect.SetActive(true);
    }
    public void GoToShopCharacters()
    {
        UI_ShopCharacters.SetActive(true);
        Manager_Game.GetManager().PauseGame();
        music.Pause();
    }

    public void GoToShopParticels()
    {
        UI_ShopParticels.SetActive(true);
    }

    public void GoToIngamePurchases()
    {
        UI_IngamePurchases.SetActive(true);
        Manager_Game.GetManager().PauseGame();
    }

    public void GoToLeaderBoard()
    {
        UI_LeaderBoard.SetActive(true);
        Manager_Game.GetManager().PauseGame();
    }

    public void GoToOptions()
    {
        UI_Options.SetActive(true);
        Manager_Game.GetManager().PauseGame();
    }  
    
    public void GoToIngameOptions()
    {
        UI_IngameOptions.SetActive(true);
    }

    public void GoToHTP()
    {
        UI_HTP.SetActive(true);
    }

    public void StartLevel()
    {
        music.Play();
        Manager_Game.GetManager().UnPauseGame();
    }

    public void PlaySound()
    {
        SoundManager.Instance.Play(clickClip);
    }
}
