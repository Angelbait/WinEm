using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    public TextMeshProUGUI[] placedBets;
    public TextMeshProUGUI[] gameResults;

    private BetManager myBM;

    private void Start()
    {
        myBM = FindObjectOfType<BetManager>().GetComponent<BetManager>();

        for (int i = 0; i < myBM.playerBets.Length; i++) 
        {
            placedBets[i].text = myBM.playerBets[i];
        }

        for (int i = 0; i < myBM.dropPositions.Length; i++)
        {
            gameResults[i].text = myBM.dropPositions[i];
        }
    }
}
