using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public PlayerController playerCont;
    private Vector3 playerStartPos;

    public Transform platformGen;
    private Vector3 platformGenStartPos;

    private PlatformDestroyer[] platforms;

    private ScoreManager scoreManager;

    public DeathScreenManager deathMngr;

    void Start()
    {
        playerStartPos = playerCont.transform.position;

        platformGenStartPos = platformGen.transform.position;

        scoreManager = FindObjectOfType<ScoreManager>();

        //platforms = FindObjectsOfType<PlatformDestroyer>();
    }

    void Update()
    {
        
    }

    public void Restart()
    {
        scoreManager.isInc = false;

        playerCont.gameObject.SetActive(false);

        deathMngr.gameObject.SetActive(true);

        //StartCoroutine("RestartCo");
    }

    public void Reset()
    {
        deathMngr.gameObject.SetActive(false);
        platforms = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(false);
        }

        playerCont.transform.position = playerStartPos;
        platformGen.position = platformGenStartPos;
        playerCont.runningSpeed = 10;
        playerCont.speedMilestoneCounter = 100;
        playerCont.gameObject.SetActive(true);

        scoreManager.score = 0;
        scoreManager.isInc = true;
    }

    public IEnumerator RestartCo()
    {
        scoreManager.isInc = false;

        playerCont.gameObject.SetActive(false);
        yield return new WaitForSeconds(1);

        platforms = FindObjectsOfType<PlatformDestroyer>();

        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(false);
        }

        playerCont.transform.position = playerStartPos;
        platformGen.position = platformGenStartPos;
        playerCont.runningSpeed = 10;
        playerCont.speedMilestoneCounter = 100;
        playerCont.gameObject.SetActive(true);

        scoreManager.score = 0;
        scoreManager.isInc = true;
    }
}
