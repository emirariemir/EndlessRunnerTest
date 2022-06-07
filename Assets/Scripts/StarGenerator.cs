using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{

    public ObjectPooler starPool;

    public float starDistance;

    public void SpawnStar(Vector3 spawnPosition)
    {
        GameObject coin1 = starPool.GetPooledObject();
        coin1.transform.position = spawnPosition;
        coin1.SetActive(true);

        GameObject coin2 = starPool.GetPooledObject();
        coin2.transform.position = new Vector3(spawnPosition.x + starDistance, spawnPosition.y, spawnPosition.z);
        coin2.SetActive(true);

        GameObject coin3 = starPool.GetPooledObject();
        coin3.transform.position = new Vector3(spawnPosition.x - starDistance, spawnPosition.y, spawnPosition.z);
        coin3.SetActive(true);
    }
}
