using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int boardNum;
    public int ballsToPlay = 5;
    public float dropInterval = 5f;
    public float ballLockTime = 2f;
    private int ballsDropped = 1;
    private int ballsLanded = 0;
    public int sceneChangeTime = 2;

    public GameObject gameBall;

    public Transform[] dropPoint;
    public TextMeshProUGUI boardNumText;
    public TextMeshProUGUI[] ballTexts;

    public string[] dropLandings;
    public BetManager myBM;

    private void Start()
    {
        myBM = FindObjectOfType<BetManager>().GetComponent<BetManager>();
        dropLandings = new string[ballsToPlay];

        StartBallSpawner();
        boardNum++;

        /*
        foreach (TextMeshProUGUI tM in ballTexts) {
            tM.text = "Waiting";
        }
        */
    }
    
    void StartBallSpawner() 
    {
        StartCoroutine(BallSpawnerTimer());
        boardNumText.text = "#" + boardNum.ToString();
    }

    IEnumerator BallSpawnerTimer() 
    {
        int spawnChooser = Random.Range(0, 8);
        GameObject currentBall = Instantiate(gameBall, dropPoint[spawnChooser]);
        currentBall.GetComponent<BallManager>().myNumber = ballsDropped.ToString();
        FindObjectOfType<FollowCamManager>().GetComponent<FollowCamManager>().ballToFollow = currentBall.transform;
        //Debug.Log("Dropping ball #" + ballsDropped.ToString());
        ballTexts[ballsDropped - 1].text = "Dropped";
        ballsDropped++;
        //Debug.Log("Dropped ball #" + ballsDropped.ToString() + " Out of: " + ballsToPlay.ToString());

        yield return new WaitForSeconds(dropInterval);
        if (ballsDropped < ballsToPlay + 1) 
        {           
            StartCoroutine(BallSpawnerTimer());
        }
    }


    public void BallHasLanded(string ballNumber, string landingPos)
    {
        //Debug.Log("Ball #" + ballNumber + " landed @ " + landingPos);        
        ballTexts[int.Parse(ballNumber) - 1].text = landingPos;
        dropLandings[int.Parse(ballNumber) - 1] = landingPos;
        ballsLanded++;

        if (ballsLanded == ballsToPlay) 
        {
            Debug.Log("Board done playing, waiting to scene change.");
            myBM.dropPositions = new string[ballsToPlay];
            myBM.dropPositions = dropLandings;
            StartCoroutine(AllBallsDroppedSceneChange());
        }        
    }

    public IEnumerator AllBallsDroppedSceneChange()
    {
        yield return new WaitForSeconds(sceneChangeTime);
        myBM.WinEmSceneChanger();
    }
}
