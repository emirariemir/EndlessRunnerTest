using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject destroyPoint;

    void Start()
    {
        destroyPoint = GameObject.Find("Destroy Point");
    }

    void Update()
    {
        if (transform.position.x < destroyPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
