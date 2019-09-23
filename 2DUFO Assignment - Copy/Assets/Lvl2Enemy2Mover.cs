using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2Enemy2Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(57 + Mathf.PingPong(Time.time, 5), transform.position.y, transform.position.z);
    }
}
