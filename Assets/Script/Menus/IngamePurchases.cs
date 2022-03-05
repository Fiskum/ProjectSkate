using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngamePurchases : MonoBehaviour
{
    public void OnClick_Back()
    {
        MenuManager.OpenMenu(Menu.Shop_Characters, gameObject);
    }

    public void OnClick_BuyChest2()
    {
        
    }
}
