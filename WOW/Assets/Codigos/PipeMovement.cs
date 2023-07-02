using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float deadZone = -40.0f;

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(-1, 0, 0) * 15 * Time.deltaTime;
        
        if (transform.position.x < deadZone){
            Destroy(gameObject);
        }
    }
}
