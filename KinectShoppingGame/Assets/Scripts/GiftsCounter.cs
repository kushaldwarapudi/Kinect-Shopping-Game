﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GiftsCounter : MonoBehaviour
{
    public Text scoreText;
    public GameObject CongratulationsCanv;
    public GameObject GameViewCanv;

    public float TimeDelay = 5f;
    public int ScoreValue;
    public float time;
    public Text TimerText;

    public int countdowntime;
    public Text CountDownText;
    
    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
        time = 60f;
        TimerText.text = "Timer : " + " " + (Mathf.Floor(time % 60f).ToString("00"));
        scoreText.text = "Score : "+"  "+ ScoreValue.ToString()+" / 14";
        CongratulationsCanv.SetActive(false);
        GameViewCanv.SetActive(true);
        this.enabled = false;
        


    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TimerText.text=  "Timer : "+" " + (Mathf.Floor(time % 60f).ToString("00"));
        if (time <= 0)
        {
            time = 0;
            TimerText.text=  "Timer : "+" " + (Mathf.Floor(time % 60f).ToString("00"));
            Debug.Log("TImeUp");
           
            if(ScoreValue < 14)
            {
                
                SceneManager.LoadScene(3);
            }
        }
        if (ScoreValue >= 14)
        {
            StartCoroutine(captureScreen());
        }
    }
    public void CountScore()
    {
        ScoreValue++;
        scoreText.text = "Score : "+"  "+ ScoreValue.ToString()+" / 14";
    }

    public IEnumerator captureScreen()
    {
        CongratulationsCanv.SetActive(true);
        CountDownText.gameObject.SetActive(true);
        GameViewCanv.SetActive(false);
        while (countdowntime > 0)
        {
            CountDownText.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        CountDownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        CountDownText.gameObject.SetActive(false);
        string directory = Application.dataPath + "/WinnersImages/";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        var imagename = "Oberoi" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        ScreenCapture.CaptureScreenshot(Path.Combine(directory,imagename));
        Debug.Log("Pic Taken");
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gift"))
        {
            CountScore();
            Destroy(other.gameObject);
        }
    }

}
