using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{

    public int pointsToGive;

    private ScoreManager scoreMngr;
    
    void Start()
    {
        scoreMngr = FindObjectOfType<ScoreManager>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreMngr.AddPoints(pointsToGive);
            gameObject.SetActive(false);
        }
    }
}
