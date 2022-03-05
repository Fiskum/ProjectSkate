using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public void OnClick_Account()
    {
        
    }
    public void OnClick_AutoStart()
    {
        
    }
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Main_Menu, gameObject);
    }
}
