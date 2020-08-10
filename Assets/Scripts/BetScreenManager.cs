using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BetScreenManager : MonoBehaviour
{
    public int ballChoiceAmount = 5;
    public int ballsChosen = 0;
    public string[] chosenBalls;
    public int ballToChoose = 0;
    public Color[] colorChoice;
    public GameObject startButtonPrecise;
    public GameObject startButtonGeneral;

    public TextMeshProUGUI[] ballChoiceTexts;

    private BetManager myBM;

    private void Start()
    {
        myBM = FindObjectOfType<BetManager>().GetComponent<BetManager>();
        chosenBalls = new string[ballChoiceAmount];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clickHit = Physics2D.Raycast(mousePos, Vector2.up, 1);

            if (clickHit.collider != null && clickHit.collider.tag == "BallButtons" && ballsChosen < ballChoiceAmount)
            {
                clickHit.collider.GetComponent<SpriteRenderer>().color = colorChoice[ballsChosen];
                ballChoiceTexts[ballsChosen].text = clickHit.collider.GetComponent<BallButton>().ballName;
                chosenBalls[ballsChosen] = clickHit.collider.GetComponent<BallButton>().ballName;
                ballsChosen++;
            }
            else if (clickHit.collider != null && clickHit.collider.tag == "PlayPrecise" && ballsChosen >= ballChoiceAmount) 
            {
                myBM.gameType = "Precise";
                myBM.playerBets = chosenBalls;
                myBM.WinEmSceneChanger();
            }
            else if (clickHit.collider != null && clickHit.collider.tag == "PlayGeneral" && ballsChosen >= ballChoiceAmount)
            {
                myBM.gameType = "General";
                myBM.playerBets = chosenBalls;
                myBM.WinEmSceneChanger();
            }
            else
            {
                Debug.Log("Did not click anything, mouse pos: " + Input.mousePosition.ToString());
            }
        }

        if (ballsChosen >= ballChoiceAmount) 
        {
            startButtonGeneral.GetComponent<SpriteRenderer>().color = Color.green;
            startButtonPrecise.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
