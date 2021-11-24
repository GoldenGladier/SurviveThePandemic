using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_npc : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject goalDestination;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent.destination = goalDestination.transform.position;
    }

    // Update is called once per frame
}
