using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandView : MonoBehaviour
{
    public Transform HandMesh;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandMesh.position = transform.position;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.gameObject.CompareTag("Gift"))
    //        return;
    //    other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Gift"))
            return;
        // collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
        
    }

   
}
