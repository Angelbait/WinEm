using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallButton : MonoBehaviour
{
    private BetScreenManager myBSM;
    public string ballName;

    private void Start()
    {
        myBSM = FindObjectOfType<BetScreenManager>();
    }

    public void SelectMe()
    {
        
    }
}
