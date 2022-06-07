using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenManager : MonoBehaviour
{
    public GameObject pauseScreen;

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }
}
