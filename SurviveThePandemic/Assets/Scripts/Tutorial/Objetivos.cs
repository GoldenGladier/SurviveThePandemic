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

    [Header("Configuracion objetivos")]
    public GameObject contenedorInstrucciones;
    public Objetivo[] objetivos;

    void Start()
    {
        contenedorInstrucciones.SetActive(false);  
        textoMision.text = objetivos[numObjetivos].texto;
        //yield return new WaitForSeconds(3.0f);
        Activa_Desactiva_Tutorial();
    }

    // Update is called once per frame
    void Update()
    {
        if(numObjetivos < objetivos.Length && tutorialActive){
            if( Input.GetKeyUp(objetivos[numObjetivos].key1) || Input.GetKeyUp(objetivos[numObjetivos].key2) ){
                    Debug.Log(objetivos[numObjetivos].mensajeConsola);
                    ActualizaObjetivo();                    
            }
        }
    }

    public IEnumerator Activa_Desactiva_Tutorial(){
        Debug.Log("Iniciando espera");
        yield return new WaitForSeconds(1);
        tutorialActive = !tutorialActive;
        Debug.Log("Tutorial: " + tutorialActive);
    }

    public void ActualizaObjetivo(){
        numObjetivos++;
        Debug.Log("Objetivo: " + numObjetivos + "/" + objetivos.Length);
        if(numObjetivos < objetivos.Length){            
            textoMision.text = objetivos[numObjetivos].texto;
        }   
        else{
            textoMision.text = "Terminaste Tutorial";
            tutorialActive = false;
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