using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BoidController : MonoBehaviour
{
    

    private GameObject[] boids;
    public int avoidRadius = 100;
    public int regroupWeight = 100;
    
    // Start is called before the first frame update
    void Start()
    {

        boids = GameObject.FindGameObjectsWithTag("boids");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBoids();
    }

    void MoveBoids()
    {
        foreach (GameObject boid in boids)
        {
            Vector3 v1 = Regroup(boid);
            Vector3 v2 = Avoid(boid);
            Vector3 v3 = Align(boid);
            
            boid.GetComponent<Rigidbody>().velocity += v1 + v2 + v3;
        }

    }
    
    
    Vector3 Regroup(GameObject b)
    {

        Vector3 center = Vector3.zero;

        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                center += boid.transform.position;
            }
        }

        center /= boids.Length - 1;

        return (center - b.transform.position) / regroupWeight;
        
    }

    Vector3 Avoid(GameObject b)
    {
        Vector3 c = Vector3.zero;

        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                if (Vector3.Distance(boid.transform.position ,b.transform.position) < avoidRadius)
                {
                    c = c - (boid.transform.position - b.transform.position);
                }
            }
        }

        return c;


    }


    Vector3 Align(GameObject b)
    {
        Vector3 pvJ = Vector3.zero;
        Vector3 vel = b.GetComponent<Rigidbody>().velocity;
        
        
        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                pvJ += vel;
            }
        }

        pvJ /= boids.Length - 1;

        return (pvJ - vel) / 8;


    }

    
    
}

