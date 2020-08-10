using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public string myNumber;

    public Material[] myWrap;

    private void Start()
    {
        Material[] mats = GetComponent<MeshRenderer>().materials;
        mats[1] = myWrap[int.Parse(myNumber) - 1];
        GetComponent<MeshRenderer>().materials = mats;
    }

    public void LockMeInPlace() 
    {
        //Lock ball in place
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
}
