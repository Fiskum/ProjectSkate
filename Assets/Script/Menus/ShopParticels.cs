using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopParticels : MonoBehaviour
{
    public void OnClick_ShopCharacters()
    {
        MenuManager.OpenMenu(Menu.Shop_Characters, gameObject);
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
