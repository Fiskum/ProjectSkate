using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public void OnClick_Play_Level1()
    {
        
    }
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Chapter_Select, gameObject);
    }
}
