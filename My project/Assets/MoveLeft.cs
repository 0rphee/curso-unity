using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 12f;

    private float bound = -15f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    // Update is called once per frame
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < bound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
