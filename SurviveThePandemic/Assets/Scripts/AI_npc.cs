using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_npc : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public GameObject goalDestination;

    private bool calculandoDestino = false;

    void Start()
    {
        navMeshAgent.destination = goalDestination.transform.position;
    }

    void Update () {
        if (navMeshAgent.remainingDistance < 2f){
            if(calculandoDestino != true){
                calculandoDestino = true;
                StartCoroutine (nuevoDestino());
            }
        }
    }    

    public IEnumerator nuevoDestino(){
        goalDestination = GeneradorDestinos.singleton.generarNuevoDestino();
        navMeshAgent.destination = goalDestination.transform.position; 
        yield return new WaitForSeconds(5f);
        calculandoDestino = false;
    }

}
