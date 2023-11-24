using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    //References
    public GameObject blinkingTrap;

    //Public
    public float timeActive = 3f;

    float timePassed = 0f;
    bool active = true;

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed > timeActive)
        {
            active = !active;
            timePassed = 0f;
            blinkingTrap.SetActive(active);
        }
    }
}
