using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI textD;
    [TextArea(30,3)]
    public string[] parrafos;
    int index;
    public float velParrafo;

    public GameObject botonContinue;
    public GameObject botonQuitar;

    public GameObject panelDialogo;
    public GameObject botonLeer;
    // Start is called before the first frame update
    void Start()
    {
        botonQuitar.SetActive(false);
        botonLeer.SetActive(false);
        panelDialogo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(textD.text == parrafos[index])
        {
            botonContinue.SetActive(false);
        }
    }

    IEnumerator TextDialogo()
    {
        foreach(char letra in parrafos[index].ToCharArray())
        {
            textD.text += letra;
            yield return new WaitForSeconds(velParrafo);
        }
    }

    public void siguienteParrafo()
    {
        botonContinue.SetActive(false);
        if(index<parrafos.Length - 1)
        {
            index++;
            textD.text = "";
            StartCoroutine(TextDialogo());
        }
        else
        {
            textD.text = "";
            botonContinue.SetActive(false);
            botonQuitar.SetActive(true);
        }
    }

    public void activarBotonLeer()
    {
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo());
    }
    public void botonCerrar()
    {
        panelDialogo.SetActive(false);
        botonLeer.SetActive(false);
    }

}
