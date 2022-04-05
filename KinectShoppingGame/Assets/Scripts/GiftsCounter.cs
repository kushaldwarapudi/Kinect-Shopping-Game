using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiftsCounter : MonoBehaviour
{
    public Text scoreText;
    public GameObject CongratulationsCanv;
    public GameObject GameViewCanv;

    public float TimeDelay = 5f;
    public int ScoreValue;
    public float time;
    public Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
        time = 60f;
        TimerText.text = "Timer : " + " " + (Mathf.Floor(time % 60f).ToString("00"));
        scoreText.text = "Score : "+"  "+ ScoreValue.ToString()+" / 14";
        CongratulationsCanv.SetActive(false);
        GameViewCanv.SetActive(true);
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
                
                SceneManager.LoadScene(2);
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
        GameViewCanv.SetActive(false);
        yield return new WaitForSeconds(TimeDelay);
        ScreenCapture.CaptureScreenshot("Oberoi"+System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
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
