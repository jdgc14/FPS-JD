using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public GameObject destination1;

    public GameObject destination2;

    private GameObject player;

    private float distanceToFollowPlayer = 15f;

    bool followingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.destination = destination1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();

        if (followingPlayer)
        {
            FollowPlayer();
        }
        else
        {
            FollowPath();
        }
    }

    void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(transform.position, player.transform.position) < distanceToFollowPlayer)
        {
            followingPlayer = true;
        }
        else
        {
            followingPlayer = false;
        }
    }

    void FollowPlayer()
    {
        navMeshAgent.destination = player.transform.position;
    }

    void FollowPath()
    {
        if (Vector3.Distance(transform.position, destination1.transform.position) < 2)
        {
            navMeshAgent.destination = destination2.transform.position;
        } else if (Vector3.Distance(transform.position, destination2.transform.position) < 2 || Vector3.Distance(transform.position, destination1.transform.position) > 8)
        {
            navMeshAgent.destination = destination1.transform.position;
        }
    }
}
