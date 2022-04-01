using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Leaderboard : MonoBehaviour
{
    [System.Serializable]
    public struct Score
    {
        public string name;
        public string clock;
        public float time;
    }

    public Score[] highScores = new Score[10];

    public Text ScoreName;
    public Text ScoreTime;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("FirstBoot") != 1)
            FirstTimeBoot();
        else
            LoadScores();

        UpdateUIScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveScores()
				{
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetString("HighScore" + i + "_Name", highScores[i].name);
            PlayerPrefs.SetFloat("HighScore" + i + "_Time", highScores[i].time);
        }
    }

    void LoadScores()
    {
        highScores = new Score[10];

        for (int i = 0; i < 10; i++)
        {
            highScores[i].name = PlayerPrefs.GetString("HighScore" + i + "_Name");
            highScores[i].time = PlayerPrefs.GetFloat("HighScore" + i + "_Time");
            highScores[i].clock = Manager_Game.TimerToClock(highScores[i].time);
        }
    }

    public void AddScore(float newTime, string newName)
    {
        if (newTime > highScores[9].time) // if it's slower than the slowest high score, skip it.
            return; 

        for (int i = 0; i < 10; i++)
        {
            if (newTime < highScores[i].time)
            {
                Score[] newHighScore = new Score[10];
                System.Array.Copy(highScores, newHighScore, 10);

                for (int j = i; j < 9; j++)
                {
                    newHighScore[j + 1] = highScores[j];
                }

                newHighScore[i].name = newName;
                newHighScore[i].time = newTime;
                newHighScore[i].clock = Manager_Game.TimerToClock(newTime);

                highScores = newHighScore;

                SaveScores();

                UpdateUIScore();

                break; // I don't want to add the same name for every slot below my best time.
            }
        }
    }

    void UpdateUIScore()
    {
        ScoreName.text = ScoreTime.text = "";

        for (int i = 0; i < 10; i++)
        {
            string name = highScores[i].name.Substring(0, Mathf.Min(highScores[i].name.Length, 16));

            ScoreName.text += (i < 9 ? "  " : "") + (i + 1) + ".\t" + name + "\n";
            ScoreTime.text += highScores[i].clock + "\n";
        }
    }

    void FirstTimeBoot()
    {
        Score[] defaultScores = new Score[10];

        defaultScores[0].name = "Jørgen Dalby";
        defaultScores[1].name = "Hanne Thoresen";
        defaultScores[2].name = "Arild Pettersen";
        defaultScores[3].name = "Connie Reinertsen";
        defaultScores[4].name = "Torstein Heggdal";
        defaultScores[5].name = "Barbro Angell";
        defaultScores[6].name = "Thorleif Tenold";
        defaultScores[7].name = "Kirsti Strømnes";
        defaultScores[8].name = "Bjørn Meyer";
        defaultScores[9].name = "Stine Vedvik";

        defaultScores[0].time = 23;
        defaultScores[0].clock = Manager_Game.TimerToClock(defaultScores[0].time);

        defaultScores[1].time = 24;
        defaultScores[1].clock = Manager_Game.TimerToClock(defaultScores[1].time);

        defaultScores[2].time = 25;
        defaultScores[2].clock = Manager_Game.TimerToClock(defaultScores[2].time);

        defaultScores[3].time = 26;
        defaultScores[3].clock = Manager_Game.TimerToClock(defaultScores[3].time);

        defaultScores[4].time = 27;
        defaultScores[4].clock = Manager_Game.TimerToClock(defaultScores[4].time);

        defaultScores[5].time = 28;
        defaultScores[5].clock = Manager_Game.TimerToClock(defaultScores[5].time);

        defaultScores[6].time = 29;
        defaultScores[6].clock = Manager_Game.TimerToClock(defaultScores[6].time);

        defaultScores[7].time = 30;
        defaultScores[7].clock = Manager_Game.TimerToClock(defaultScores[7].time);

        defaultScores[8].time = 31;
        defaultScores[8].clock = Manager_Game.TimerToClock(defaultScores[8].time);

        defaultScores[9].time = 32;
        defaultScores[9].clock = Manager_Game.TimerToClock(defaultScores[9].time);

        highScores = defaultScores;
        SaveScores();

        Debug.Log("Performed a first time boot of the High Score.");
        PlayerPrefs.SetInt("FirstBoot", 1);
    }
}
