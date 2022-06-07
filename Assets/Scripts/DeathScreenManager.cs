using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    public void Restart()
    {
        FindObjectOfType<GameManager>().Reset();
    }
}
