using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI textD;
    [TextArea(30,3)]
    public string[] parrafos;
    public Sprite[] ayudaVisual;
    int index;
    public float velParrafo;

    public GameObject botonContinue;
    public GameObject botonQuitar;

    public GameObject panelDialogo;
    public GameObject botonLeer;
    public Button buttonChange;

    // Start is called before the first frame update
    void Start()
    {
        botonContinue.SetActive(false);
        botonQuitar.SetActive(false);
        botonLeer.SetActive(true);
        //       panelDialogo.SetActive(false);

     //   desplegarImagenes.SetActive(true);
        panelDialogo.SetActive(true);
        StartCoroutine(TextDialogo());
    }

    // Update is called once per frame
    void Update()
    {
        if(textD.text == parrafos[index])
        {
            botonContinue.SetActive(true);
        }
    }

    IEnumerator TextDialogo()
    {
        buttonChange.image.sprite = ayudaVisual[index];
        foreach (char letra in parrafos[index].ToCharArray())
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
      //  desplegarImagenes.SetActive(false);
        botonLeer.SetActive(false);
    }

}
