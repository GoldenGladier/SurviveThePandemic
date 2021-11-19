using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : MonoBehaviour
{
    public int estadoActual = 0;
    public EstadoDialogo[] estados;

    public void OnTriggerStay(Collider other){
        //Debug.Log("Detecte colision");
        if(other.CompareTag("Player")){
            //Debug.Log("Detecte al Player");
            if(Input.GetKeyDown(ControlsDialog.singleton.configuracion.teclaInicioDialogo) || 
                Input.GetKeyDown(ControlsDialog.singleton.configuracion.teclaInicioDialogo2) )
            {
                Debug.Log("Detecte tecla B");
                StartCoroutine( ControlsDialog.singleton.Decir(estados[estadoActual].frases) );                
            }
        }
    }
}
