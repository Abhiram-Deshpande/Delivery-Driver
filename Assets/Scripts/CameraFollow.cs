using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject thingToFollow;
    // Update is called once per frame
    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10f);
        
    }
}
