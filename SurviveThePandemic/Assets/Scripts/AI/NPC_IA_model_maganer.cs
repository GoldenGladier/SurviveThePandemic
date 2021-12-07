using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_IA_model_maganer : MonoBehaviour
{
    // Singleton
    public static NPC_IA_model_maganer singleton;

    // Arreglo de destinos    
    public GameObject[] NPC_IA_Models;

    // Permitir acceso desde otro script
    private void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(gameObject);
        }
    }    

    public GameObject generarModeloAleatorio(){
        int nModelo = Random.Range(0, NPC_IA_Models.Length);
        // Debug.Log("Destino Modelo: " + nModelo);
        return NPC_IA_Models[nModelo];
    }
}
