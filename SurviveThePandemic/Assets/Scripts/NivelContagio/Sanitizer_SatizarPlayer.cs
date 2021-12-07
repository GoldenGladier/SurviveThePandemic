using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanitizer_SatizarPlayer : MonoBehaviour
{
    VidaPlayer playerVida;
    public GameObject Player;
    public int Curar = 0;

    // public int cantidad;
    public float cleanTime = 1;
    float currentCleanTime;    

    void Start()
    {
        playerVida = Player.GetComponent<VidaPlayer>();
    }

    private void OnTriggerStay(Collider other)
    {
        // Debug.Log("Sanitizer --> " + other.tag );
        if (other.tag == "Player" && playerVida.vida < 100)
        {
            // Debug.Log("Curando...");
            currentCleanTime += Time.deltaTime;
            if (currentCleanTime > cleanTime)
            {
                playerVida.vida += Curar;
                currentCleanTime = 0.0f;
            }
        }
    }
}
