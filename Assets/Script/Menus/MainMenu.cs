using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnClick_ChapterSelect()
    {
        MenuManager.OpenMenu(Menu.Chapter_Select, gameObject);
    }
    
    public void OnClick_Options()
    {
        MenuManager.OpenMenu(Menu.Options, gameObject);
    }

    public void OnClick_HTP()
    {
        MenuManager.OpenMenu(Menu.HTP, gameObject);
    }
        public void OnClick_Shop()
    {
        MenuManager.OpenMenu(Menu.Shop_Characters, gameObject);
    }
    public void OnClick_LeaderBoard()
    {
        MenuManager.OpenMenu(Menu.LeaderBoards1, gameObject);
    }
}
