using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerManager : MonoBehaviour
{
    private Animator myAnimator;
    public float speedModifier = 0.5f;
    public float maxSpeed = 1.5f;

    private void Start()
    {       
        myAnimator = GetComponent<Animator>();

        float randoSpeed = Random.Range(0, (maxSpeed * 4f));
        float finalSpeed = (speedModifier * randoSpeed) - maxSpeed;
        if (finalSpeed == 0f) { finalSpeed = 1f; }      
        myAnimator.SetFloat("CustomSpeed", finalSpeed);
        //Debug.Log("My spin speed is: " + finalSpeed.ToString());
    }
}
