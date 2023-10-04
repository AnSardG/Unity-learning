using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireballHolder : MonoBehaviour
{
    [Header ("Enemy references")]
    [SerializeField] private Transform enemyTransform;

    Vector3 lastScale;
    EnemyProjectile[] activeProjectiles;

    private void Awake()
    {
        lastScale = new Vector3(enemyTransform.localScale.x, enemyTransform.localScale.y, enemyTransform.localScale.z);
    }

    private void Update()
    {
        
        if (lastScale != enemyTransform.localScale)        
        {
            activeProjectiles = GetComponentsInChildren<EnemyProjectile>(false);
            foreach(EnemyProjectile projectile in activeProjectiles)
            {               
                projectile.Deactivate();
            }
            lastScale = new Vector3(enemyTransform.localScale.x, enemyTransform.localScale.y, enemyTransform.localScale.z);
            UpdateScale();
        }
    }

    private void UpdateScale()
    {
        transform.localScale = enemyTransform.localScale;
    }
}
