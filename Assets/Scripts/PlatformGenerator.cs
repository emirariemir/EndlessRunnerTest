using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform spawnPoint;
    private float distance;
    public float minDistance = 1;
    public float maxDistance = 5;
    

    
    public int platformSelection;
    public float[] platformWidths;

    private float maxHeight;
    private float minHeight;
    public Transform maxHeightPoint;

    public ObjectPooler[] objPoolers;

    private StarGenerator starGenerator;
    public float starPercentage;

    void Start()
    {

        starGenerator = FindObjectOfType<StarGenerator>();
        
        platformWidths = new float[objPoolers.Length];

        for (int i = 0; i < objPoolers.Length; i++)
        {
            platformWidths[i] = objPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        maxHeight = maxHeightPoint.position.y;
        minHeight = transform.position.y;

    }

    void Update()
    {
        if (transform.position.x < spawnPoint.position.x)
        {
            distance = Random.Range(minDistance, maxDistance);

            platformSelection = Random.Range(0, objPoolers.Length);

            float newY = Random.Range(minHeight, maxHeight);

            float newX = transform.position.x + distance + (platformWidths[platformSelection]/2);
            transform.position = new Vector3(newX, newY, transform.position.z);

            GameObject newPlatform = objPoolers[platformSelection].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < starPercentage)
            {
                starGenerator.SpawnStar(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelection] / 2), newY, transform.position.z);
        }
    }
}
