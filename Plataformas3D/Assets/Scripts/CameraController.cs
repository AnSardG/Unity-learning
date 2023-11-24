using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //References
    public GameObject player;

    //Public variables
    public float zDistance = 10f, yDistance = 6f;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 
            player.transform.position.y + yDistance, 
            player.transform.position.z - zDistance);
    }
}
