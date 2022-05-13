using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClapScript : MonoBehaviour
{
    private bool gamestart;



    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (gamestart)
            return;
        if (collision.gameObject.name == "HandLeft" || collision.gameObject.name == "HandRight")
        {
            gamestart = true;
            GiftManager.Instance.StartGame();
        }
    }
}
