using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamManager : MonoBehaviour
{
    public Transform ballToFollow;

    void Update()
    {
        if (ballToFollow != null) 
        {
            this.transform.position = new Vector3 (this.transform.position.x, ballToFollow.position.y, this.transform.position.z);
        }
    }
}
