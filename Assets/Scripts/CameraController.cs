using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController pc;

    private Vector3 lastPlayerPos;
    private float moveDistance;

    void Start()
    {
        pc = FindObjectOfType<PlayerController>();
        lastPlayerPos = pc.transform.position;
    }

    void Update()
    {
        moveDistance = pc.transform.position.x - lastPlayerPos.x;
        transform.position = new Vector3(transform.position.x + moveDistance, transform.position.y, transform.position.z);
        lastPlayerPos = pc.transform.position;
    }
}
