using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public int type;
    public Sprite krest;

    void Start()
    {
        type = 0;
    }

    private void OnMouseDown()
    {
        if (type == 0 && GameObject.Find("GameController").GetComponent<GameController>().GameOver == false && GameObject.Find("GameController").GetComponent<GameController>().GameOn)
        {
            type = 1;
            GetComponent<SpriteRenderer>().sprite = krest;
            GameObject.Find("GameController").GetComponent<StartGame>().movePlayer = false;
        }
    }
}
