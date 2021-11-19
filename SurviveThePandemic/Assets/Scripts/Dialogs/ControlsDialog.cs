using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsDialog : MonoBehaviour
{
    // Singleton
    public static ControlsDialog singleton;

    public GameObject dialogo;
    public Text txtDialogo;
    [Header("Config de teclado")]
        public ConfigDialogos configuracion;

    [Header("Ensayos")]
    public Frase[] dialogoEnsayo;

    private void Awake(){
        if(singleton == null){
            singleton = this;
        }
        else{
            DestroyImmediate(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogo.SetActive(false);   
    }

    // Update is called once per frame
    public IEnumerator Decir(Frase[] _dialogo){
        dialogo.SetActive(true);
        for( int i = 0; i < _dialogo.Length; i++){

            txtDialogo.text = "";
            for(int j = 0; j < _dialogo[i].texto.Length + 1; j++){
                yield return new WaitForSeconds(configuracion.tiempoLetra);
                if(Input.GetKey(configuracion.teclaSkip) || Input.GetKey(configuracion.teclaSkip2)){
                    j = _dialogo[i].texto.Length; 
                }
                txtDialogo.text = _dialogo[i].texto.Substring(0, j);                
            }

            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil( () => Input.GetKeyUp(configuracion.teclaSiguienteFrase) );
        }        
        dialogo.SetActive(false);
    }

    [ContextMenu("Activar Prueba")]
    public void Prueba(){
        StartCoroutine (Decir(dialogoEnsayo));
    }
}

[System.Serializable]
public class Frase
{
    public string texto;
}

[System.Serializable]
public class EstadoDialogo
{
    public Frase[] frases;
}