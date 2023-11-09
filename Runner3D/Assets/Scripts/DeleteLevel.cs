using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    public LevelSpawner ls;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        ls.Spawn();
    }
}
