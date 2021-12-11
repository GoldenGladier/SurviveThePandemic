using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ruta : MonoBehaviour
{

    public GameObject panelMision;
    public GameObject panelSiguiente;
    public GameObject elemento;
    public GameObject siguienteElemento;


    void Start()
    {
        panelMision.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelMision.SetActive(false);
            siguienteElemento.SetActive(true);
            Destroy(elemento);
            panelSiguiente.SetActive(true);

        }
    }
}
