using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 3 + Mathf.PingPong(Time.time, 5), transform.position.z);
    }
}
