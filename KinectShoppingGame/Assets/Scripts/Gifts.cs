using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gifts : MonoBehaviour
{
    public float Speed;
    public float RotSpeed;
    public Transform[] MovePoint;

    // Start is called before the first frame update
    void Start()    
    {
        if(GetComponent<Rigidbody>())
        {
          var  rb = GetComponent<Rigidbody>();
       
          rb.useGravity = false;
          
          rb.AddForce(Vector3.right * Speed * Time.deltaTime);
        }
        else
        {
          var rb = GetComponent<Rigidbody2D>();
         
          rb.gravityScale = 0;
          
          rb.AddForce(Vector3.right * Speed * Time.deltaTime);

        }
       
      
    }

    // Update is called once per frame
    void Update()
    {
       // int randomPos = Random.Range(0, MovePoint.Length);
        
        // transform.Translate(Vector3.right * Speed * Time.deltaTime);
     //   transform.Rotate(-5 * RotSpeed * Time.deltaTime, -2 * RotSpeed * Time.deltaTime, 0);
        //transform.position = Vector3.MoveTowards(this.transform.position, MovePoint[randomPos].position, Speed * Time.deltaTime);

    }
}
