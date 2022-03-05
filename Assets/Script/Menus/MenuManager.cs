using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, chapterSelect, levelSelect, pause, ingameOptions, win, lose, shopCharacters, shopParticels, ingamePurchases, ingamePurchasesConfirm, leaderBoards1, leaderBoards2, options, hTP;
    public static void Init()
    {
        GameObject cavas = GameObject.Find("Canvas");
        mainMenu = cavas.transform.Find("MainMenu").gameObject;
        chapterSelect = cavas.transform.Find("ChapterSelect").gameObject;
        levelSelect = cavas.transform.Find("LevelSelect").gameObject;
        pause = cavas.transform.Find("Pause").gameObject;
        ingameOptions = cavas.transform.Find("InGameOptions").gameObject;
        win = cavas.transform.Find("Win").gameObject;
        lose = cavas.transform.Find("Lose").gameObject;
        shopCharacters = cavas.transform.Find("ShopCharacters").gameObject;
        shopParticels = cavas.transform.Find("ShopParticels").gameObject;
        ingamePurchases = cavas.transform.Find("IngamePurchases").gameObject;
        ingamePurchasesConfirm = cavas.transform.Find("IngamePurchasesConfirm").gameObject;
        leaderBoards1 = cavas.transform.Find("LeaderBoards1").gameObject;
        leaderBoards2 = cavas.transform.Find("LeaderBoards2").gameObject;
        options = cavas.transform.Find("Options").gameObject;
        hTP = cavas.transform.Find("HTP").gameObject;

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();
        switch (menu)
        {
            case Menu.Main_Menu:
                mainMenu.SetActive(true);
                break;
            case Menu.Chapter_Select:
                chapterSelect.SetActive(true);
                break;
            case Menu.Level_Select:
                levelSelect.SetActive(true);
                break;
            case Menu.Pause:
                pause.SetActive(true);
                break;
            case Menu.Ingame_Options:
                ingameOptions.SetActive(true);
                break;
            case Menu.Win_Menu:
                win.SetActive(true);
                break;
            case Menu.Lose_Menu:
                lose.SetActive(true);
                break;
            case Menu.Shop_Characters:
                shopCharacters.SetActive(true);
                break;
            case Menu.Shop_Particels:
                shopParticels.SetActive(true);
                break;
            case Menu.Ingame_Purchases:
                ingamePurchases.SetActive(true);
                break;
            case Menu.Ingame_PurchasesConfirm:
                ingamePurchasesConfirm.SetActive(true);
                break;
            case Menu.LeaderBoards1:
                leaderBoards1.SetActive(true);
                break;
            case Menu.LeaderBoards2:
                leaderBoards2.SetActive(true);
                break;
            case Menu.Options:
                options.SetActive(true);
                break;
            case Menu.HTP:
                hTP.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
}