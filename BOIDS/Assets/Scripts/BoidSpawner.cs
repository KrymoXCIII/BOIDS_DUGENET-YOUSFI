using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject boidPrefab;

    public int numBoids;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numBoids; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            Vector3 velocity = new Vector3(Random.Range(5, 10), Random.Range(5, 10), Random.Range(5, 10));

            GameObject boid = Instantiate(boidPrefab, position, Quaternion.identity);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
