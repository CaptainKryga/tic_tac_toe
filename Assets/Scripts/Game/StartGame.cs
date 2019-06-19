using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public GameObject box;
    public Sprite noll;
    public Text text;
    public bool movePlayer;
    
    private GameObject[,] map = new GameObject[3,3];
    int x, y, move, n, k;
    void Start()
    {
        move = 0;
        movePlayer = true;
        for (y = 0; y < 3; y++)
        {
            for (x = 0; x < 3; x++)
            {
                map[y, x] = Instantiate(box);
                map[y, x].transform.position = new Vector3(x * 3, y * -3, 0);
            }
        }
    }

    void Update()
    {
        if (!movePlayer && GetComponent<GameController>().GameOver == false)
        {
            if (move == 0)
            {
                defenceOne();
                movePlayer = true;
                move++;
            }
            else if (move > 0)
            {
                if (defenceTwo() == 1)
                    attackOne();
                movePlayer = true;

            }
            if (checkWin(2) == 1)
            {
                GetComponent<GameController>().GameOver = true;
                text.text = "Computer win";
            }
            else if (checkWin(1) == 1)
            {
                GetComponent<GameController>().GameOver = true;
                text.text = "Player win";
            }
            else if (checkGameOver() == 1)
            {
                GetComponent<GameController>().GameOver = true;
                text.text = "Draw";      
            }
        }
    }
    
    private int checkWin(int type)
    {
        if (map[0, 0].GetComponent<Cell>().type == type && map[0, 1].GetComponent<Cell>().type == type && map[0, 2].GetComponent<Cell>().type == type)
            return (1);
        if (map[1, 0].GetComponent<Cell>().type == type && map[1, 1].GetComponent<Cell>().type == type && map[1, 2].GetComponent<Cell>().type == type)
            return (1);
        if (map[2, 0].GetComponent<Cell>().type == type && map[2, 1].GetComponent<Cell>().type == type && map[2, 2].GetComponent<Cell>().type == type)
            return (1);
        if (map[0, 0].GetComponent<Cell>().type == type && map[1, 0].GetComponent<Cell>().type == type && map[2, 0].GetComponent<Cell>().type == type)
            return (1);
        if (map[0, 1].GetComponent<Cell>().type == type && map[1, 1].GetComponent<Cell>().type == type && map[2, 1].GetComponent<Cell>().type == type)
            return (1);
        if (map[0, 2].GetComponent<Cell>().type == type && map[1, 2].GetComponent<Cell>().type == type && map[2, 2].GetComponent<Cell>().type == type)
            return (1);
        if (map[0, 0].GetComponent<Cell>().type == type && map[1, 1].GetComponent<Cell>().type == type && map[2, 2].GetComponent<Cell>().type == type)
            return (1);
        if (map[2, 0].GetComponent<Cell>().type == type && map[1, 1].GetComponent<Cell>().type == type && map[0, 2].GetComponent<Cell>().type == type)
            return (1);
        return (0);
    }
    
    private int checkGameOver()
    {
        for (y = 0; y < 3; y++)
        {
            for (x = 0; x < 3; x++)
            {
                if (map[y, x].GetComponent<Cell>().type == 0)
                    return (0);
            }
        }
        return (1);
    }
    
    private void attackOne()
    {
        x = y = 0;
        for (y = 0; y < 3; y++)
        {
            for (x = 0; x < 3; x++)
            {
                if (map[y, x].GetComponent<Cell>().type == 0)
                {
                    map[y, x].GetComponent<SpriteRenderer>().sprite = noll;
                    map[y, x].GetComponent<Cell>().type = 2;
                    return; 
                }
            }
        }
    }
    
    private int defenceTwo()
    {
        if (checkLines(ref x, ref y) != 0)
        {
            map[y, x].GetComponent<SpriteRenderer>().sprite = noll;
            map[y, x].GetComponent<Cell>().type = 2;
            return (0);
        }
        if (checkCols(ref x, ref y) != 0)
        {
            map[x, y].GetComponent<SpriteRenderer>().sprite = noll;
            map[x, y].GetComponent<Cell>().type = 2;
            return (0);
        }
        if (checkDiagonals(ref x, ref y) != 0)
        {
            map[y, x].GetComponent<SpriteRenderer>().sprite = noll;
            map[y, x].GetComponent<Cell>().type = 2;
            return (0);
        }
        return (1);
    }
    
    private void defenceOne()
    {
        if (map[1, 1].GetComponent<Cell>().type == 0)
        {
            map[1, 1].GetComponent<SpriteRenderer>().sprite = noll;
            map[1, 1].GetComponent<Cell>().type = 2;
        }
        else
        {
            x = y = 1;
            while (x == 1)
                x = Random.Range(0, 3);
            while (y == 1)
                y = Random.Range(0, 3);
            map[y, x].GetComponent<SpriteRenderer>().sprite = noll;
            map[y, x].GetComponent<Cell>().type = 2;
        }
    }

    private int checkDiagonals(ref int x, ref int y)
    {
        int save_x, save_y;
        save_x = save_y = 0;
        n = k = x = 0;
        for (y = 0; y < 3; y++)
        {
            print(y + " " + x);
            if (map[x, y].GetComponent<Cell>().type == 0)
            {
                save_x = x;
                save_y = y;
                n++;
            }
            if (map[x, y].GetComponent<Cell>().type == 1)
            {
                k++;
            }
            x++;
        }
        if (k == 2 && n == 1)
        {
            x = save_x;
            y = save_y;
            return (1);
        }
        n = k = x = 0;
        for (y = 2; y >= 0; y--)
        {
            if (map[x, y].GetComponent<Cell>().type == 0)
            {
                save_x = x;
                save_y = y;
                n++;
            }
            if (map[x, y].GetComponent<Cell>().type == 1)
            {
                k++;
            }
            x++;
        }
        if (k == 2 && n == 1)
        {
            x = save_x;
            y = save_y;
            return (1);
        }
        
        return (0);
    }
    
    private int checkCols(ref int x, ref int y)
    {
        int save_x, save_y;
        save_x = save_y = 0;
        for (y = 0; y < 3; y++)
        {
            n = k = 0;
            for (x = 0; x < 3; x++)
            {
                if (map[x, y].GetComponent<Cell>().type == 0)
                {
                    save_x = x;
                    save_y = y;
                    n++;
                }

                if (map[x, y].GetComponent<Cell>().type == 1)
                {
                    k++;
                }
            }
            if (k == 2 && n == 1)
            {
                x = save_x;
                y = save_y;
                return (1);
            }
        }
        return (0);
    }
    
    private int checkLines(ref int x, ref int y)
    {
        int save_x, save_y;
        save_x = save_y = 0;
        for (y = 0; y < 3; y++)
        {
            n = k = 0;
            for (x = 0; x < 3; x++)
            {
                if (map[y, x].GetComponent<Cell>().type == 0)
                {
                    save_x = x;
                    save_y = y;
                    n++;
                }
                if (map[y, x].GetComponent<Cell>().type == 1)
                {
                    k++;
                }
            }
            if (k == 2 && n == 1)
            {
                x = save_x;
                y = save_y;
                return (1);
            }
        }
        return (0);
    }

    
}
