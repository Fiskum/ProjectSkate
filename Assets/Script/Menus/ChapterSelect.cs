using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSelect : MonoBehaviour
{
    public void OnClick_LevelSelect()
    {
        MenuManager.OpenMenu(Menu.Level_Select, gameObject);
    }
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Main_Menu, gameObject);
    }
}
