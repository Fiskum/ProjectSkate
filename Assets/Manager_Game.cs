using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Game : MonoBehaviour
{
				[Header("Values")]
    public float timer;
    public float timer_unPause = 2f;
    public float goal_x = 783.2f;
    public float death_y = -33.7f;

    [Header("Assignable Variables")]
    public Transform playerTransform;
    private Rigidbody2D playerRigid;
    private Vector3 playerDefaultPosition;

    [Header("Assignable UI Elements")]
    public Text UI_Timer;



    // Start is called before the first frame update

    void Awake()
    {
  
        if (playerTransform != null)
        {
            playerDefaultPosition = playerTransform.position;
            playerRigid = playerTransform.GetComponent<Rigidbody2D>();
        }
        else
            Debug.LogError("ERROR: Please assign the player object to the 'playerTransform' variable.");


        PauseGame();
        timer_unPause = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer_unPause != -1)
        {
            timer_unPause -= Time.deltaTime;

            if (timer_unPause < 0)
                PauseGame();
 
        }
        

        bool isPaused = playerRigid.isKinematic == true;

        


        if(!isPaused)
            InGame();






        UpdateUI();


    }

    void InGame()
    {
        timer += Time.deltaTime;

        Vector2 playerPosition = playerTransform.position;

        if(playerPosition.y < death_y)
								{
            Restart();
								}

        if (playerPosition.x > goal_x)
        {
            Restart();
        }
    }


    public void PauseGame()
				{
        bool isPaused = playerRigid.bodyType == RigidbodyType2D.Static;


        playerRigid.bodyType = isPaused ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;


        timer_unPause = -1;


    }

    public void Restart()
    {
        playerTransform.position = playerDefaultPosition;
        timer = 0;

        PauseGame();
        timer_unPause = 2;
    }


    void UpdateUI()
    {
        if (UI_Timer != null)
        {
            float minutes = Mathf.Floor(timer / 60);
            float seconds = Mathf.Floor(timer) - minutes * 60;
            float milliseconds = Mathf.Floor(timer * 100) - minutes * 6000 - seconds * 100;
            float microseconds = Mathf.Floor(timer * 10000) - minutes * 600000 - seconds * 10000 - milliseconds * 100;

            UI_Timer.text = (seconds < 10 ? "0" : "") + seconds + (milliseconds < 10 ? ":0" : ":") + milliseconds + (microseconds < 10 ? ":0" : ":") + microseconds;

            UI_Timer.transform.localScale = Vector3.one * (milliseconds < 10 ? 1.2f : 1);
        }
    }
}
