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

      if (PlayerPrefs.GetInt("FirstBoot") != 2)
            FirstTimeBoot();

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
        if (newTime < highScores[9].time) // if the new time is less than the slowest time, return.
            return;

        if (newName.Length < 1)
            newName = "My Personal Score";
        else
        {
            newName = newName.ToLower();
            newName = char.ToUpper(newName[0]) + newName.Substring(1);
        }

     

        for (int i = 0; i < 10; i++)
        {
            if (newTime > highScores[i].time)
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
        ScoreName.text = "High Scores: \n";
        ScoreTime.text = "Time: \t\t\n";

        for (int i = 0; i < 10; i++)
        {
            string name = highScores[i].name.Substring(0, Mathf.Min(highScores[i].name.Length, 18));

            ScoreName.text += (i < 9 ? "  " : "") + (i + 1) + ".\t" + name + "\n";
            ScoreTime.text += highScores[i].clock + "\n";
        }
    }

    void FirstTimeBoot()
    {
        Score[] defaultScores = new Score[10];

        float defaultTime = 81.43235f;

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

        for (int i = 0; i < 10; i++)
        {
            defaultScores[i].time = defaultTime - (i * 4.712345f); // A seemingly random number (but not really)
            defaultScores[i].clock = Manager_Game.TimerToClock(defaultScores[i].time);
        }

        highScores = defaultScores;
        SaveScores();

        Debug.Log("Performed a first time boot of the High Score.");
        PlayerPrefs.SetInt("FirstBoot", 2); // Second itteration of the highscore system.
    }
}
