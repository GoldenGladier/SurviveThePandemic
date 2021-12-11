using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TextMeshPro
using TMPro;

public class VidaPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}
    public float vida = 100;

    [Header("Configuracion Barra de Vida")]
    public Image barraDeVida;
    public TextMeshProUGUI nContagioText;
    // MENU GAME OVER
    [Header("Configuracion Game Over")]
    public GameObject interfaceGameOver;
    public AudioSource Musica;
    public AudioClip CancionGameOver; 

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100); //Minimo y Maximo de Vida
        barraDeVida.fillAmount = vida / 100; 
        nContagioText.text = (100-vida) + "%";
        // nContagioText.text = (100-vida) + "%/100%";

        if(vida <= 0){
            if(interfaceGameOver.activeSelf == false){
                Debug.Log(" MUERTO ");
                interfaceGameOver.SetActive(true);
                if(Musica && CancionGameOver){
                    Musica.Pause();
                    Musica.clip = CancionGameOver;
                    Musica.Play(0);       
                }
            }
        }        
    }
}
