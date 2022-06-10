using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    NavMeshAgent agent;
    Transform target;
    [SerializeField] Player playerScript;
    Vector3 randomLook;
    Quaternion randomPosition;

    private float speed = 5f;

    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        agent = GetComponent<NavMeshAgent>();
        randomLook = new Vector3(Random.Range(0, 200), 0, Random.Range(0, 200));
        randomPosition = Quaternion.LookRotation(randomLook - transform.position);
    }


    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        var targetRotation = Quaternion.LookRotation(target.position - transform.position);
        if (playerScript.isOnArea)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            agent.destination = target.position;
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, randomPosition, speed * Time.deltaTime);
            agent.destination = transform.position;
        }

        

    }
}
