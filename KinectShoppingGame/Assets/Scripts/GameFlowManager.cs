﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ResetGame();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}