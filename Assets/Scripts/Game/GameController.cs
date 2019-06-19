using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool GameOn;
    public bool GameOver;
    public GameObject pause;
    public GameObject gameOver;

    void Start()
    {
        GameOn = true;
        GameOver = false;
    }
    void Update()
    {
        if (!GameOver)
        {
            if (GameOn && Input.GetKeyDown(KeyCode.Escape))
            {
                GameOn = false;
                pause.SetActive(true);
            }
            else if (!GameOn && Input.GetKeyDown(KeyCode.Escape))
            {
                GameOn = true;
                pause.SetActive(false);
            }
            gameOver.SetActive(false);
        }
        else
        {
            gameOver.SetActive(true);
            pause.SetActive(false);
        }
    }
}
