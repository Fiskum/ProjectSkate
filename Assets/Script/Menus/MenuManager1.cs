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

    public void GoToMainMenu()
    {
        UI_MainMenu.SetActive(true);
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
    }

    public void GoToShopParticels()
    {
        UI_ShopParticels.SetActive(true);
    }

    public void GoToIngamePurchases()
    {
        UI_IngamePurchases.SetActive(true);
    }

    public void GoToLeaderBoard()
    {
        UI_LeaderBoard.SetActive(true);
    }

    public void GoToOptions()
    {
        UI_Options.SetActive(true);
    }  
    
    public void GoToIngameOptions()
    {
        UI_IngameOptions.SetActive(true);
    }

    public void GoToHTP()
    {
        UI_HTP.SetActive(true);
    }


}