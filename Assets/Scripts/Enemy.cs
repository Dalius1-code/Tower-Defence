using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private int taregtIndex;
    private NavMeshAgent agent;
    private bool endPointReached = false;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        if (!endPointReached)
        {
            agent.SetDestination(Path.instance.waypoints[taregtIndex].position);
                    
            var distance = Vector3.Distance(transform.position, Path.instance.waypoints[taregtIndex].position);
                    
            if (distance < 1.5f)
            {
                taregtIndex++;
                if (taregtIndex >= Path.instance.waypoints.Count)
                {
                    endPointReached = true;
                }
            }
        }
        else
        {
            //attack
        }
        
    }
}
