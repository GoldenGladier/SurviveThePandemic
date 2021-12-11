using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objFinal : MonoBehaviour
{
    public GameObject panelMision;
    public GameObject panelAnterior;
    public GameObject elemento;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            panelAnterior.SetActive(false);
            panelMision.SetActive(true);
            Destroy(elemento);
        }
    }
}
