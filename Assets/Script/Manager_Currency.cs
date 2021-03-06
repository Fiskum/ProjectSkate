using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Currency : MonoBehaviour
{

    public enum ItemType
    {recolorSkin, Skin, Particle}

    [System.Serializable]
    public struct Item
    {
        public string name;
        public ItemType type;
        public int price;
        public bool alreadyPurchased;
        public Color colorModifer;
        public Button button;
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
    ParticleSystem[] playerParticles;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GetComponent<Manager_Game>();
        playerParticles = playerRenderer.GetComponentsInChildren<ParticleSystem>();

        if (PlayerPrefs.GetInt("Currency_FirstBoot") != 1)
            FirstTimeBoot();

        for (int i = 0; i < Items.Length; i++)
        {
            Item currentItem = Items[i];

            currentItem.alreadyPurchased = PlayerPrefs.GetInt(currentItem.name) == -1;
            if(!currentItem.alreadyPurchased)
                PlayerPrefs.SetInt(currentItem.name, currentItem.price);
        }


        for (int i = 0; i < Items.Length; i++)
        {
            Item currentItem = Items[i];

            currentItem.button.onClick.AddListener(delegate { SelectItem(currentItem.name); });

            if(i != 0)
                Items[i].button.interactable = true;
        }
    }


				#region Currency
				public int RewardRun(float time) /// Returns a number representing coins earned.
    {
        float coinPerSecond = (float)priceForSkin / (minutesToEarnSkin * 60);

        int earnedCoins = Mathf.FloorToInt(time * coinPerSecond);
        int currentCoins = PlayerPrefs.GetInt("Currency_Coin");

        PlayerPrefs.SetInt("Currency_Coin", currentCoins + earnedCoins);
        Debug.Log("Deposited '" + earnedCoins + "' coins to your account. \nYour current balance is '" + (currentCoins + earnedCoins) + "' coins.");

        return earnedCoins;
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
            Items[i].button.interactable = true;
            if (name == Items[i].name)
            {
                currentItem = Items[i];
              
            }
        }

        bool isUnlocked = PlayerPrefs.GetInt("name") == -0;

        if (isUnlocked)
        {
            currentItem.button.interactable = false;

            if (currentItem.type == ItemType.recolorSkin)
                playerRenderer.color = currentItem.colorModifer;

            if (currentItem.type == ItemType.Particle)
                for (int j = 0; j < playerParticles.Length; j++)
                {
                    playerParticles[j].startColor = currentItem.colorModifer;
                }
        }

    }
}
