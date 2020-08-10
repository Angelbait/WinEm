using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BetManager : MonoBehaviour
{
    //Holds the bets across all Scenes
    public string[] playerBets;
    public string gameType;

    public string[] dropPositions;

    public static BetManager instance = null;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance == null)
        {
            instance = this;
        } 
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void WinEmSceneChanger() 
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Betting") 
        {
            SceneManager.LoadScene("Game");
        } 
        else if (currentScene.name == "Game")
        {
            SceneManager.LoadScene("Results");
        } 
        else if (currentScene.name == "Results")
        {
            SceneManager.LoadScene("Betting");
        }

        /*
        Debug.Log("Gametype chosen: " + gameType);

        for (int i = 0; i < playerBets.Length; i++)
        {
            Debug.Log("Chosen spots: " + playerBets[i]);
        }
        */
    }
}
