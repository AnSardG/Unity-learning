using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lap : MonoBehaviour
{
    LapManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponentInParent<LapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {            
            manager.UpdateCheckpoint(other.gameObject.GetComponent<PlayerController>().playerNumber - 1, gameObject.tag);
        }
    }
}
