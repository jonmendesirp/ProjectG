using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    
    NavMeshAgent agent; 
    Transform target;

    public bool playerIsOnArea = false; 

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if(playerIsOnArea) transform.LookAt(target);
        else transform.LookAt(new Vector3(Random.Range(0, 200), Random.Range(0, 200), Random.Range(0, 200)));
        agent.destination = target.position;
        
    }
}
