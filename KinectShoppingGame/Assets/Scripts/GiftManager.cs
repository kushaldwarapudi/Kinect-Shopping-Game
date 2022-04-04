using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftManager : MonoBehaviour
{
    public GameObject[] Gifts;
    public Transform[] SpawnPoints;
    public float MinDelay;
    public float MaxDelay;
    public int RandomGift;
    // Start is called before the first frame update
    void Start()
    {
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
