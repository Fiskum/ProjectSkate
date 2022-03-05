using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCharacters : MonoBehaviour
{
    public void OnClick_ShopParticels()
    {
        MenuManager.OpenMenu(Menu.Shop_Particels, gameObject);
    }

    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Main_Menu, gameObject);
    }
    public void OnClick_Ingame_Purchasess()
    {
        MenuManager.OpenMenu(Menu.Ingame_Purchases, gameObject);
    }
}
