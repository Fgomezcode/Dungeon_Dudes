using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    LevelSpawnerTest boardScript;

    private int level = 3;

    public static GameManager instance = null;

    private void Awake()
    {
        if(instance = null)
        {
            instance = this;

        }
        else if(instance !=  null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<LevelSpawnerTest>();
        initGame();
    }


    void initGame()
    {
        boardScript.setupScene(level);
    }
}
