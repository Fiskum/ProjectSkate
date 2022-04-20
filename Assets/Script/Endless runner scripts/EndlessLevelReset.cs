using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessLevelReset : MonoBehaviour
{
    public Transform PlatformGenerator;
    private Vector2 PlatformStartPoint;

    private PlatformDestroyer[] platformList;

    public Manager_Game theManager;


    void Start()
    {
        PlatformStartPoint = PlatformGenerator.position;
        //playerStartPosition = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
    }
    public IEnumerator RestartGameCo()
    {
        //thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);


        platformList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platformList.Length; i++)
        {
           platformList[i].gameObject.SetActive(false);
           
        }

        //thePlayer.transform.position = playerStartPosition;
        PlatformGenerator.position = PlatformStartPoint;
        //thePlayer.gameObject.SetActive(true);
    }
}
