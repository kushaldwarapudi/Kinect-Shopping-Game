using System.Collections;
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
    public GameObject TvDisplay;
    public GameObject Shoppingbag;
    public GameObject CaptureIcon;

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
        TimerText.text = "Timer : " + " 60";
        scoreText.text = "Score : "+" "+ ScoreValue.ToString()+" / 14";
       // scoreText.text = "Score : " + " " + "14" + " / 14";
        CongratulationsCanv.SetActive(false);
        GameViewCanv.SetActive(true);
        this.enabled = false;
        TvDisplay.SetActive(true);
        Shoppingbag.SetActive(false);
        CaptureIcon.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

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
        // ScoreValue=ScoreValue+14;
        scoreText.text = "Score : " + " " + ScoreValue.ToString() + " / 14";
        // scoreText.text = "Score : "+""+ "14"+"/14";
    }

    public IEnumerator captureScreen()
    {
        CongratulationsCanv.SetActive(true);
        CountDownText.gameObject.SetActive(true);
        GameViewCanv.SetActive(false);
        TvDisplay.SetActive(true);
        while (countdowntime > 0)
        {
            CountDownText.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        
        
        


    }
    public void TakePicture()
    {
        StartCoroutine(Capture());
    }
    public IEnumerator Capture()
    {
        CaptureIcon.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        CountDownText.text = "READY!";
        yield return new WaitForSeconds(1f);
        CountDownText.gameObject.SetActive(false);
        #region Commented
        //string directory = Application.dataPath + "/WinnersImages/";
        //if (!Directory.Exists(directory))
        //{
        //    Directory.CreateDirectory(directory);
        //}
        //var imagename = "Oberoi" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".png";
        //ScreenCapture.CaptureScreenshot(Path.Combine(directory,imagename));
        //Debug.Log("Pic Taken");
        #endregion
        ScreenShot.Instance.TakeScreenShot();
        yield return new WaitForSeconds(2f);
        var s = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(s);
        CaptureIcon.SetActive(true);

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
