using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRayCollisions : MonoBehaviour
{
    //Reference
    private LaserRay laserRay;

    private void Awake()
    {
        laserRay = GetComponentInParent<LaserRay>();
    }

    private void DisableRay()
    {
        laserRay.DisableCollider();
    }

    private void EnableRay()
    {
        laserRay.EnableCollider();
    }
}
