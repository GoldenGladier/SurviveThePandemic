using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    public enum RisksTypes
    {
        Verde = 1,
        Amarillo = 10,
        Naranja = 25,
        Rojo = 50,
    }
    public RisksTypes Riesgo = RisksTypes.Verde; 

    public class RiskType
    {
        public string Name = "Risk";
        public int Damage = 1;  

        public RiskType(string name, int damage){
            this.Name = name;
            this.Damage = damage;
        }  
    }
    private RiskType Risk = new RiskType("None", 0);

    VidaPlayer playerVida;
    public GameObject Player;
    public static ManipuladorVida singleton;

    // public int cantidad;
    public float damageTime = 1;
    float currentDamageTime;

    // Start is called before the first frame update
    void Start()
    {
        // playerVida = GameObject.FindWithTag("Player").GetComponent<VidaPlayer>();
        playerVida = Player.GetComponent<VidaPlayer>();
        Debug.Log(Riesgo);
        switch(Riesgo)
        {
            case RisksTypes.Verde:
                Risk.Name = "Verde";
                Risk.Damage = 2;
                break;
            case RisksTypes.Amarillo:
                Risk.Name = "Amarillo";
                Risk.Damage = 10;
                break;
            case RisksTypes.Naranja:
                Risk.Name = "Naranja";
                Risk.Damage = 25;
                break;
            case RisksTypes.Rojo:
                Risk.Name = "Rojo";
                Risk.Damage = 50;
                break;                                                
        }
        Debug.Log(Risk.Name);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC" && Risk != null)
        {
            // Debug.Log(" RIESGO: " + Risk.Name + "  DAÑO: " + Risk.Damage);
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                playerVida.vida -= Risk.Damage;
                currentDamageTime = 0.0f;
            }
        }
    }
   
}

