using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Currency : MonoBehaviour
{

    public enum ItemType
    {Skin, Particle}

    [System.Serializable]
    public struct Item
    {
        public string name;
        public ItemType type;
        public int price;
        public bool alreadyPurchased;
        public Color colorModifer;
    }


    Manager_Game GameManager;

    [Header("Currency Settings")]
    public int priceForSkin = 1000;
    public int priceForParticles = 250;
    public int minutesToEarnSkin = 60; // en time

    [Header("Purchasable Items")]

    public Item[] Items;

    [Header("Variables")]
    public SpriteRenderer playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GetComponent<Manager_Game>();

        if (PlayerPrefs.GetInt("Currency_FirstBoot") != 1)
            FirstTimeBoot();

        for (int i = 0; i < Items.Length; i++)
        {
            Item currentItem = Items[i];

            currentItem.alreadyPurchased = PlayerPrefs.GetInt(currentItem.name) == -1;
            if(!currentItem.alreadyPurchased)
                PlayerPrefs.SetInt(currentItem.name, currentItem.price);
        }
    }


				#region Currency
				public void RewardRun(float time)
    {
        float coinPerSecond = (float)priceForSkin / (minutesToEarnSkin * 60);

        int earnedCoins = Mathf.FloorToInt(time * coinPerSecond);
        int currentCoins = PlayerPrefs.GetInt("Currency_Coin");

        PlayerPrefs.SetInt("Currency_Coin", currentCoins + earnedCoins);
        Debug.Log("Deposited '" + earnedCoins + "' coins to your account. \nYour current balance is '" + (currentCoins + earnedCoins) + "' coins.");
    }

    public bool MakePurchase(string itemID)
    {
        if (!PlayerPrefs.HasKey(itemID))
        {
            Debug.Log("Error:\nThe item does not exist.");
            return false;
        }

        int currentCoins = PlayerPrefs.GetInt("Currency_Coin");
        int itemPrice = PlayerPrefs.GetInt(itemID);

        if (itemPrice == -1)
        {
            Debug.Log("Error:\nThe item has already been purchased.");
            return false;
        }

        if (itemPrice > currentCoins)
        {
            Debug.Log("The item is too expensive.");
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("Currency_Coin", currentCoins - itemPrice);
            PlayerPrefs.SetInt(itemID, -1);

            Debug.Log("Purchase:\nYou have been charged '" + itemPrice + "' coins.");
        }

        return true;
    }

    void FirstTimeBoot()
    {
        PlayerPrefs.SetInt("Currency_Coin", Mathf.RoundToInt(priceForSkin * 0.5f)); // Halveis til et skinn

        for (int i = 0; i < Items.Length; i++)
        {
            Item currentItem = Items[i];
            currentItem.alreadyPurchased = false;
            PlayerPrefs.SetInt(currentItem.name, currentItem.price);
        }


        PlayerPrefs.SetInt("Currency_FirstBoot", 1);
    }

    #endregion

    public void SelectItem(string name)
    {

        bool isBuying = MakePurchase(name);

        Item currentItem = new Item();

        for (int i = 0; i < Items.Length; i++)
        {
            if (name == Items[i].name)
            {
                currentItem = Items[i];
                break;
            }
        }


        bool isUnlocked = PlayerPrefs.GetInt("name") == -0;

        if (isUnlocked)
								{
            if(currentItem.type == ItemType.Skin)
                playerRenderer.color = currentItem.colorModifer;
								}

    }
}
