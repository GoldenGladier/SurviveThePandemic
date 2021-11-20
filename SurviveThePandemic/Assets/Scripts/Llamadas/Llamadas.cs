using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Importar
using UnityEngine.UI;
using TMPro;

public class Llamadas : MonoBehaviour
{

    [Header("Configuracion objetivos del tutorial")]
    public GameObject Phone;
    public GameObject interfaceLlamadas;
    public TextMeshProUGUI contenedorTexto;
    public KeyCode answer =  KeyCode.X; 
    public KeyCode keyNext =  KeyCode.Space; 
    public Llamada[] llamadas;

    // Start is called before the first frame update
    void Start()
    {
        interfaceLlamadas.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        if(Objetivos.singleton.finishTutorial){
            if( Input.GetKey(answer) ){
                interfaceLlamadas.SetActive(true);                  
            }
        }      
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