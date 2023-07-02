using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaritoScript : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public float flapStrength=5;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D=GetComponent<Rigidbody2D>(); 
        logic = GameObject.find("GameManager").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space) && logic.isDead == false)
       {
            _rigidbody2D.velocity = Vector2.up * flapStrength;
       }
    }
}
