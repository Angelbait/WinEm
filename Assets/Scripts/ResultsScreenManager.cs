using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsScreenManager : MonoBehaviour
{
    private BetManager myBM;
    void Start()
    {
        myBM = FindObjectOfType<BetManager>().GetComponent<BetManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D clickHit = Physics2D.Raycast(mousePos, Vector2.up, 1);

            if (clickHit.collider != null && clickHit.collider.tag == "ReturnButton")
            {
                myBM.WinEmSceneChanger();
            }
            else
            {
                Debug.Log("Did not click anything, mouse pos: " + Input.mousePosition.ToString());
            }
        }
    }
}
