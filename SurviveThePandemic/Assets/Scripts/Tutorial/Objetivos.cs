using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar
using UnityEngine.UI;
using TMPro;

public class Objetivos : MonoBehaviour
{
    public bool tutorialActive = false;
    public int numObjetivos = 0;
    public TextMeshProUGUI textoMision;

    [Header("Configuracion objetivos del tutorial")]
    public GameObject contenedorInstrucciones;
    public Objetivo[] objetivos;

    void Start()
    {
        contenedorInstrucciones.SetActive(false);  
        textoMision.text = objetivos[numObjetivos].texto;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorialActive && (numObjetivos < objetivos.Length) ){
            if( Input.GetKeyUp(objetivos[numObjetivos].key1) || Input.GetKeyUp(objetivos[numObjetivos].key2) ){
                    Debug.Log(objetivos[numObjetivos].mensajeConsola);
                    ActualizaObjetivo();                    
            }
        }
        else if(numObjetivos < objetivos.Length){
            StartCoroutine(Activa_Tutorial());            
        }
    }

    public IEnumerator Activa_Tutorial(){
        //Debug.Log("Iniciando espera");
        yield return new WaitForSeconds(2);
        tutorialActive = true;
        contenedorInstrucciones.SetActive(true);  
        Debug.Log("Tutorial: " + tutorialActive);
    }
    public IEnumerator Desactiva_Tutorial(){
        yield return new WaitForSeconds(2);
        tutorialActive = false;
        contenedorInstrucciones.SetActive(false);  
        Debug.Log("Tutorial: " + tutorialActive);
    }    

    public void ActualizaObjetivo(){
        numObjetivos++;
        Debug.Log("Objetivo: " + numObjetivos + "/" + objetivos.Length);
        if(numObjetivos < objetivos.Length){            
            textoMision.text = objetivos[numObjetivos].texto;
        }   
        else{
            textoMision.text = "¡Completaste el tutorial!";
            StartCoroutine(Desactiva_Tutorial());    
        }   
    }

}

[System.Serializable]
public class Objetivo
{
    public string texto;
    public KeyCode key1 =  KeyCode.UpArrow;
    public KeyCode key2 =  KeyCode.W;
    public string mensajeConsola = "Detecte tecla W";        
}