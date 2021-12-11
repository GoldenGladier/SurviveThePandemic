using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    VidaPlayer playerVida;

    public int cantidad;
  
    // Start is called before the first frame update
    void Start()
    {
        playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>(); 
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player") {
            playerVida.vida += cantidad;
            Destroy(gameObject);
        }
        
    }
  
}
