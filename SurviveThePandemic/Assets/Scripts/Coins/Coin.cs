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
    public GameObject Player;
    private CountCoins coins_reference;
    private VidaPlayer playerVida;

    [Header("Next Coin")]   
    public GameObject NextCoin;

    private bool coin_working = false;
    // Start is called before the first frame update
    void Start()
    {
        coins_reference = Player.GetComponent<CountCoins>();
        playerVida = Player.GetComponent<VidaPlayer>();
    }

    void Update()
    {
        if(playerVida.vida < 0){
            AudioCoin.Pause();
        }
    }    

    private IEnumerator OnTriggerStay(Collider other)
    {
        // Debug.Log("Sanitizer --> " + other.tag );
        if (other.tag == "Player" && coin_working != true)
        {
            coin_working = true;
            AudioCoin.Pause();
            AudioCoin.loop = false;
            AudioCoin.clip = take_sound;
            AudioCoin.Play(0);
            coins_reference.Coins++;
            yield return new WaitForSeconds(0.8f);
            ContenedorPadre.SetActive(false);
            // yield return new WaitForSeconds(1);
            NextCoin.SetActive(true);
        }
    }    

}
