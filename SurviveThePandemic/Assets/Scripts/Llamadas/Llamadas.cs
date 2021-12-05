using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar
using UnityEngine.UI;
using TMPro;

public class Llamadas : MonoBehaviour
{
    private bool callAnswer = false;
    private bool callSound = false;

    [Header("Notificaciones")]
    public GameObject Notificacion;
    public Transform AnimateNotification;
    public TextMeshProUGUI txtNotificacion; 
    public string textoNotificacion = "Presiona X para contestar";  

    [Header("Llamadas")]
    public AudioSource Phone;
    public AudioClip vozCaller;    
    public AudioClip vozAnswer;    
    public GameObject interfaceLlamadas;
    public Transform AnimateCall;
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
            else if( Input.GetKey(configuracion.ContestarLlamada) && callAnswer == false){                
                StartCoroutine( AnswerCall() );  
                callAnswer = true;              
            }
        }              
    }

    public IEnumerator StartCall(){
        Phone.Play(0);
        callSound = true;      
        Debug.Log("Ring Ring");          
        yield return new WaitForSeconds(2);
        txtNotificacion.text = textoNotificacion;
        Notificacion.SetActive(true);
        AnimateNotification.localPosition = new Vector2(0, -Screen.height);
        AnimateNotification.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;          
        //yield return new WaitForSeconds(2);        
    }

    public IEnumerator AnswerCall(){
        interfaceLlamadas.SetActive(true);

        AnimateCall.localPosition = new Vector2(0, -Screen.height);
        AnimateCall.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;          
        
        Phone.Pause();
        callSound = true;
        AnimateNotification.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        yield return new WaitForSeconds(1);
        Notificacion.SetActive(false);
        StartCoroutine( SimularDialogos(llamadas[0].dialogos, llamadas[0].answer, llamadas[0].caller) );           
    }

    public IEnumerator SimularDialogos(Dialogo[] dialogos, string answer, string caller){
        for( int i = 0; i < dialogos.Length; i++){
            contenedorTexto.text = "";
            if(dialogos[i].talker == caller){
                Debug.Log("MAMA");
                Phone.clip = vozCaller;
            }
            else
            {
                Debug.Log("STEVEN");
                Phone.clip = vozAnswer;
            }  
            Phone.Play(0);       
            for(int j = 0; j < dialogos[i].text.Length + 1; j++){
                yield return new WaitForSeconds(configuracion.tiempoLetra);
                if(Input.GetKey(configuracion.teclaSkip) || Input.GetKey(configuracion.teclaSkip2)){
                    j = dialogos[i].text.Length; 
                }
                contenedorTexto.text = dialogos[i].talker + ": " + dialogos[i].text.Substring(0, j);                
            }

            yield return new WaitForSeconds(0.5f);
            Phone.Pause();
            yield return new WaitUntil( () => Input.GetKeyUp(configuracion.teclaSiguienteFrase) );            
        }
        AnimateCall.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        yield return new WaitForSeconds(1);        
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
    [TextArea(minLines:3, maxLines:10)]
    public string text;
}

