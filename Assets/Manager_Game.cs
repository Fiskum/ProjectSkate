using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoBehaviour
{
    public enum GameStates
    {
        Playing, Pause, Countdown
    }

    public GameStates gameState = GameStates.Pause;

    [Header("Values")]
    public float timerStartingValue = 30;
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

    [Header("Pause Screen")]
    public GameObject UI_Pause;

    [Header("Lose Screen")]
    public GameObject UI_PauseScreen;
    public Text UI_PauseScreen_Time;
    public Slider UI_PauseScreen_Progress;
    public Text UI_PauseScreen_Percentage;
    public Button UI_PauseScreen_Return;

    [Header("Victory Screen")]
    public GameObject UI_VictoryScreen;
    public Text UI_VictoryScreen_Time;
    public GameObject UI_VictoryScreen_HighScore;
    public Button UI_VictoryScreen_Return;

    [Header("Music")]
    public AudioSource music;
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

        Restart();

        PauseGame();
        //Unpause();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameState == GameStates.Pause)
        {
            if (timer_unPause != -1)
            {
                timer_unPause -= Time.deltaTime;

                if (timer_unPause < 0)
                    UnPauseGame(-1);
            }
        }


        if (gameState == GameStates.Playing)
            InGame();


        UpdateUI();
    }

    void InGame()
    {
        timer -= Time.deltaTime;

        Vector2 playerPosition = playerTransform.position;

        if (playerPosition.y < death_y || timer <= 0)
        {
            OnLose();

        }

        if (playerPosition.x > goal_x)
        {
            OnVictory();
        }
    }


    public void OnLose()
    {
        if (UI_PauseScreen != null)
        {
            if (timer <= 0)
                timer = 0; // This is to ensure the final time won't be a negative number.

            UI_PauseScreen.SetActive(true);
            UI_PauseScreen_Time.text = TimerToClock(timerStartingValue - timer);


            float totalDistance = goal_x + playerDefaultPosition.x;
            float progress = playerTransform.position.x / totalDistance;

            UI_PauseScreen_Progress.value = progress;
            UI_PauseScreen_Percentage.text = "" + Mathf.Floor(progress * 100) + "%";

            UI_PauseScreen_Return.onClick.RemoveAllListeners();
            UI_PauseScreen_Return.onClick.AddListener(RestartApp);
        }

        Restart();
    }

    public void OnVictory()
    {
        if (UI_VictoryScreen != null)
        {
            UI_VictoryScreen.SetActive(true);
            UI_VictoryScreen_Time.text = TimerToClock(timerStartingValue - timer);

            UI_VictoryScreen_Return.onClick.RemoveAllListeners();
            UI_VictoryScreen_Return.onClick.AddListener(RestartApp);
        }

        Restart();
    }

    public void PauseGame()
    {
        gameState = GameStates.Pause;
        timer_unPause = -1;

        playerRigid.bodyType = RigidbodyType2D.Static;
    }

    /// UnPauseDelay is the delay between unpausing, and the game resuming again. Leave it blank for the default, which is 2 seconds.
    public void UnPauseGame(float unPauseDelay = 2)
    {
        if (unPauseDelay != -1)
        {
            timer_unPause = unPauseDelay;
            return;
        }

        UI_PauseScreen.SetActive(false);
        UI_VictoryScreen.SetActive(false);

        playerRigid.bodyType = RigidbodyType2D.Dynamic;
        gameState = GameStates.Playing;
    }

    public void Restart()
    {
        playerTransform.position = playerDefaultPosition;
        timer = timerStartingValue;

        PauseGame();
        UnPauseGame();
    }


    void UpdateUI()
    {
        if (UI_Timer != null)
        {

            if (gameState == GameStates.Playing)
                UI_Timer.text = TimerToClock(timer);
            else
                UI_Timer.text = TimerToClock(timer_unPause);
          


            //UI_Timer.transform.localScale = Vector3.one * (milliseconds < 10 ? 1.2f : 1);
        }


        if (UI_PauseScreen != null)
        {

        }
    }

    void RestartApp()
    {
     
        music.Stop();
        // SceneManager.LoadScene(0);
    }

				#region tools

    static string TimerToClock(float currentTime)
    {
        float minutes = Mathf.Floor(currentTime / 60);
        float seconds = Mathf.Floor(currentTime) - minutes * 60;
        float milliseconds = Mathf.Floor(currentTime * 100) - minutes * 6000 - seconds * 100;
        float microseconds = Mathf.Floor(currentTime * 10000) - minutes * 600000 - seconds * 10000 - milliseconds * 100;

        string clockTime = "";

        if (minutes < 1)
            clockTime = (seconds < 10 ? "0" : "") + seconds + (milliseconds < 10 ? ":0" : ":") + milliseconds + (microseconds < 10 ? ":0" : ":") + microseconds;
        else
            clockTime = (minutes < 10 ? "0" : "") + minutes + (seconds < 10 ? ":0" : ":") + seconds + (milliseconds < 10 ? ":0" : ":") + milliseconds;

        return clockTime;
    }

    public static Manager_Game GetManager()
    {
        return GameObject.Find("_ScriptManager").GetComponent<Manager_Game>();
    }

				#endregion
}
