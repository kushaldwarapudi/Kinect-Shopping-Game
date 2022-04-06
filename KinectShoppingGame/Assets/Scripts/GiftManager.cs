using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GiftManager : MonoBehaviour
{
    public static GiftManager Instance;
    public GameObject[] Gifts;
    public GiftsCounter giftCounter;
    public Transform[] SpawnPoints;
    public float MinDelay;
    public float MaxDelay;
    public int RandomGift;
    public int countdowntime;
    public Text CountDownText;
    public TMP_Text ClapText;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void StartGame()
    {
        ClapText.gameObject.SetActive(false);
        StartCoroutine(CountDownTimer());
    }
    public IEnumerator CountDownTimer()
    {
        while (countdowntime > 0)
        {
            CountDownText.text = countdowntime.ToString();
            yield return new WaitForSeconds(1f);
            countdowntime--;
        }
        CountDownText.text = "Go!";
        yield return new WaitForSeconds(1f);
        CountDownText.gameObject.SetActive(false);
        giftCounter.enabled = true;
        StartCoroutine(SpawnGifts());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SpawnGifts()
    {
        while (true)
        {
            RandomGift = Random.Range(0, Gifts.Length);
            float delay = Random.Range(MinDelay, MaxDelay);

            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, SpawnPoints.Length);
            Transform spawnPoint = SpawnPoints[spawnIndex];

            GameObject SpawnedGifts = Instantiate(Gifts[RandomGift], spawnPoint.position, spawnPoint.rotation);
            Destroy(SpawnedGifts, 15f);
        }
    }
}
