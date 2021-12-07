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

    public Image barraDeVida;
    public TextMeshProUGUI nContagioText;

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100); //Minimo y Maximo de Vida
        barraDeVida.fillAmount = vida / 100; 
        nContagioText.text = (100-vida) + "%";
        // nContagioText.text = (100-vida) + "%/100%";
    }
}
