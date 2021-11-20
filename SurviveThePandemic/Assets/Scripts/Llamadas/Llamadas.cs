using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar
using UnityEngine.UI;
using TMPro;

public class Llamadas : MonoBehaviour
{
    //private bool callAnswer = false;
    private bool callSound = false;

    [Header("Notificaciones")]
    public GameObject Notificacion;
    public TextMeshProUGUI txtNotificacion; 
    public string textoNotificacion = "Presiona X para contestar";  

    [Header("Llamadas")]
    public AudioSource Phone;
    public GameObject interfaceLlamadas;
    public TextMeshProUGUI contenedorTexto;
    //public KeyCode KeyAnswer = KeyCode.X; 
    //public KeyCode keyNext = KeyCode.Space; 
    public Llamada[] llamadas;

    [Header("Configuracion de teclado")]
    public ConfigDialogos configuracion;    

    // Start is called before the first frame update
    void Start()
    {
        interfaceLlamadas.SetActive(false);  
        Notificacion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Objetivos.singleton.finishTutorial){
            if(callSound == false){                
                StartCoroutine( StartCall() );       
            }
            else if( Input.GetKey(configuracion.ContestarLlamada) ){                
                AnswerCall();  
                //callAnswer = true;              
            }
        }              
    }

    public IEnumerator StartCall(){
        Phone.Play(0);
        yield return new WaitForSeconds(2);
        callSound = true;
        Debug.Log("Ring Ring");
        txtNotificacion.text = textoNotificacion;
        Notificacion.SetActive(true);
        //yield return new WaitForSeconds(2);        
    }

    public void AnswerCall(){
        interfaceLlamadas.SetActive(true);    
        Phone.Pause();
        callSound = true;
        Notificacion.SetActive(false);
        StartCoroutine( SimularDialogos(llamadas[0].dialogos) );           
    }

    public IEnumerator SimularDialogos(Dialogo[] dialogos){
        for( int i = 0; i < dialogos.Length; i++){
            contenedorTexto.text = "";
            for(int j = 0; j < dialogos[i].text.Length + 1; j++){
                yield return new WaitForSeconds(configuracion.tiempoLetra);
                if(Input.GetKey(configuracion.teclaSkip) || Input.GetKey(configuracion.teclaSkip2)){
                    j = dialogos[i].text.Length; 
                }
                contenedorTexto.text = dialogos[i].talker + ": " + dialogos[i].text.Substring(0, j);                
            }

            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil( () => Input.GetKeyUp(configuracion.teclaSiguienteFrase) );
        }
        interfaceLlamadas.SetActive(false);         
    }    

}

[System.Serializable]
public class Llamada
{
    public string caller;
    public string answer;
    public Dialogo[] dialogos;
}

[System.Serializable]
public class Dialogo
{
    public string talker;
    public string text;
}