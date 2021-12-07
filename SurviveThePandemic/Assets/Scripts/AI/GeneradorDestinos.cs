using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDestinos : MonoBehaviour
{
    // Singleton
    public static GeneradorDestinos singleton;

    // Arreglo de destinos    
    public GameObject[] destinos;

    // Permitir acceso desde otro script
    private void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(gameObject);
        }
    }    
    // ---------------------------------

    // void Start()
    // {
    //     Debug.Log("Destinos: " + destinos.Length);
    //     InvokeRepeating("generarNuevoDestino", 0f, 1.5f);
    // }  

    public GameObject generarNuevoDestino(){
        int nDestino = Random.Range(0, destinos.Length);
        // Debug.Log("Destinos: " + destinos.Length);
        // Debug.Log("Destino nuevo: " + nDestino);
        return destinos[nDestino];
    }
}
