using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HTP : MonoBehaviour
{
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Main_Menu, gameObject);
    }
}
