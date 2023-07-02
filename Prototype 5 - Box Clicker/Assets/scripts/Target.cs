using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        explosionParticle = GetComponent<ParticleSystem>();

        targetRb.AddForce(GetRandomForce(), ForceMode.Impulse);

        // make it spin
        targetRb.AddTorque(GetRandomTorque(), GetRandomTorque(), GetRandomTorque(), ForceMode.Impulse);

        targetRb.transform.position = GetRandomSpawnPosition();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!other.CompareTag("Bad")){
            gameManager.GameOver();
        }
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
    }

    Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }

    float GetRandomTorque()
    {
        return Random.Range(-10, 10);
    }

    Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
