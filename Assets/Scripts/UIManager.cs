using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI uiText;
    
    public Button startButton;
    
    public TextMeshProUGUI pauseText;

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        pauseText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        uiText.text = "Score: " + GameManager.Instance.GetGamePoint() + "\nLength: " + GameManager.Instance.GetLength()+ "\nSpace Pause ";
    }
    public void StartGame()
    {
        
        GameManager.Instance.GameStart();
        startButton.gameObject.SetActive(false);
    }
    public void PauseGame()
    {
        
        if (GameManager.Instance.isPause)
        {
            pauseText.gameObject.SetActive(false);
        }
        else
        {
            pauseText.gameObject.SetActive(true);
        }
        GameManager.Instance.GamePause();
    }
    public Button getStartButton()
    {
            return startButton.GetComponent<Button>();
        }
}
