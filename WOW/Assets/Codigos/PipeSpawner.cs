using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate=1f;
    private float timer =0f;

    public float bottomLimit = -13;
    public float topLimit = 13;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnpipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer> spawnRate)
        {
            timer=0f;
            Instantiate(pipePrefab, new Vector3(40,0,0),pipePrefab.transform.rotation );
        }
        else
        {
            timer += Time.deltaTime;
        }
        
    }

    void spawnpipe()
    {
        float randomHeight = Random.Range(bottomLimit, topLimit);
        Instantiate(pipePrefab, new Vector3(40, 0, 0), pipePrefab.transform.rotation);
    }
}
