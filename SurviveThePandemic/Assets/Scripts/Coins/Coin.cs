using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TEXTMESH PRO
using UnityEngine.UI;
using TMPro;

public class Coin : MonoBehaviour
{

    [Header("Coin")]
    public GameObject ContenedorPadre;
    public AudioSource AudioCoin;
    public AudioClip take_sound;    
    public TextMeshProUGUI contenedorTexto;

    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        // Debug.Log("Sanitizer --> " + other.tag );
        if (other.tag == "Player")
        {
            AudioCoin.Pause();
            AudioCoin.loop = false;
            AudioCoin.clip = take_sound;
            AudioCoin.Play(0);
            yield return new WaitForSeconds(0.8f);
            ContenedorPadre.SetActive(false);
        }
    }    

}
