using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class MenuController : MonoBehaviour
{
    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void OnClickReturn()
    {
        GetComponent<GameController>().GameOn = true;
        GetComponent<GameController>().pause.SetActive(false);
    }
}
