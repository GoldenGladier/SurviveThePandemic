using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar
using UnityEngine.UI;
using TMPro;

public class Objetivos : MonoBehaviour
{
    // Singleton
    public static Objetivos singleton;
    //

    public bool tutorialActive = false;
    public bool finishTutorial = false;
    public int numObjetivos = 0;
    public TextMeshProUGUI textoMision;

    [Header("Configuracion objetivos del tutorial")]
    public GameObject contenedorInstrucciones;
    public Transform box;

    public Objetivo[] objetivos;

    private void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(gameObject);
        }
    }

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
        else if( (numObjetivos < objetivos.Length) && (tutorialActive == false) ){
            StartCoroutine(Activa_Tutorial());            
        }
    }

    public IEnumerator Activa_Tutorial(){
        //Debug.Log("Iniciando espera");
        tutorialActive = true;
        yield return new WaitForSeconds(2);
        
        contenedorInstrucciones.SetActive(true); 

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;         
        //Debug.Log("Tutorial: " + tutorialActive);
    }
    public IEnumerator Desactiva_Tutorial(){
        tutorialActive = false;
        yield return new WaitForSeconds(2);
        
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        yield return new WaitForSeconds(1);
        contenedorInstrucciones.SetActive(false);  
        Debug.Log("Tutorial: " + tutorialActive);
        finishTutorial = true;
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