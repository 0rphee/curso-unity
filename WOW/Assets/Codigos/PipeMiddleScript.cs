using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        LogicScript logic = GetComponent<LogicScript>();
    }


    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            score += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
