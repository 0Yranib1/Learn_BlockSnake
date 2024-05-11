using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float gamePoint;
    public int length;
    public bool isStart;
    public bool isGameOver;
    public bool isPause;

    
    private void Start()
    {
        Time.timeScale = 0;
        isStart = true;
        isPause = false;
        isGameOver = false;
    }
    
    public void GameOver()
    {
        isStart = false;
        isGameOver = true;
        Time.timeScale = 0;
        UIManager.Instance.getStartButton().gameObject.SetActive(true);
    }

    public void AddGamePoint(float point)
    {
        gamePoint += point;
        length += 1;
    }
    
    public  void ResetGame()
    {
            gamePoint = 0;
            length = 0;
    }
    
    public int GetLength()
    {
        return length;
    }
    public float GetGamePoint()
    {
        return gamePoint;
    }
    
    public  void GameStart()
    {
        isStart = true;
        isGameOver = false;
        Time.timeScale = 1;
    }

    public void GamePause()
    {
        if(!isPause && !isGameOver && isStart)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else if(isPause && !isGameOver && isStart)
        {
            Time.timeScale = 1;
            isPause = false;
        }
    }

}
