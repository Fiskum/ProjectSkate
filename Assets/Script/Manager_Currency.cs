using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Currency : MonoBehaviour
{
    Manager_Game GameManager;

    [Header("Currency Settings")]
    public int priceForSkin = 1000;
    public int priceForParticles = 250;
    public int minutesToEarnSkin = 60; // en time

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GetComponent<Manager_Game>();

        if (PlayerPrefs.GetInt("Currency_FirstBoot") != 1)
            FirstTimeBoot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RewardRun(float time)
    {
        float coinPerSecond = (float)priceForSkin / (minutesToEarnSkin * 60);

        int earnedCoins = Mathf.FloorToInt(time * coinPerSecond);
        int currentCoins = PlayerPrefs.GetInt("Currency_Coin");

        PlayerPrefs.SetInt("Currency_Coin", currentCoins + earnedCoins);
        Debug.Log("Deposited '" + earnedCoins + "' coins to your account. \nYour current balance is '" + (currentCoins + earnedCoins) + "' coins.");
    }

    public void MakePurchase(string itemID, int price)
    {
        if (!PlayerPrefs.HasKey(itemID))
        {
            Debug.Log("Error:\nThe item does not exist.");
            return;
        }

        int currentCoins = PlayerPrefs.GetInt("Currency_Coin");
        int itemPrice = PlayerPrefs.GetInt(itemID);

        if (itemPrice == -1)
        {
            Debug.Log("Error:\nThe item has already been purchased.");
            return;
        }

        if (itemPrice > currentCoins)
        {
            Debug.Log("The item is too expensive.");
            return;
        }
        else
        {
            PlayerPrefs.SetInt("Currency_Coin", currentCoins - itemPrice);
            PlayerPrefs.SetInt(itemID, -1);

            Debug.Log("Purchase:\nYou have been charged '" + itemPrice + "' coins.");
        }
    }

    void FirstTimeBoot()
    {
        PlayerPrefs.SetInt("Currency_Coin", Mathf.RoundToInt(priceForSkin * 0.5f)); // Halveis til et skinn


        PlayerPrefs.SetInt("Currency_FirstBoot", 1);
    }
}
