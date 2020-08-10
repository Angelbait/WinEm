using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallToucherManager : MonoBehaviour
{
    public string myPosition;
    private float ballDelayTime;
    private Coroutine triggerCo;

    private GameManager myGM;
    void Start()
    {
        myGM = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        ballDelayTime = myGM.ballLockTime;
    }

    private void OnTriggerStay(Collider col)
    {
        GameObject ballCol = col.gameObject;
        if (triggerCo == null)
        {
            triggerCo = StartCoroutine(BallContactTime(ballCol));
            //Debug.Log("Starting Co");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        GameObject ballCol = col.gameObject;
        if (triggerCo != null)
        {
            StopCoroutine(triggerCo);
            triggerCo = null;
            //Debug.Log("Stopping Co");
        }
    }

    IEnumerator BallContactTime(GameObject ballThatCollided) {
        yield return new WaitForSeconds(ballDelayTime);
        ballThatCollided.GetComponent<BallManager>().LockMeInPlace();
        myGM.BallHasLanded(ballThatCollided.GetComponent<BallManager>().myNumber, myPosition);
    }
}
