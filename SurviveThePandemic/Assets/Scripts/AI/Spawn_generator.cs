using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_generator : MonoBehaviour
{

    //----------------------------------
    // Enemy Prefabs
    //----------------------------------
    public GameObject NPC_IA_Model;

    // public GameObject EasyEnemy;
    // public GameObject MediumEnemy;
    // public GameObject HardEnemy;
    // public GameObject BossEnemy;
    //----------------------------------
    // End of Enemy Prefabs
    //----------------------------------
 
    //----------------------------------
    // Enemies and how many have been created and how many are to be created
    //----------------------------------
    public int totalEnemy = 10;
    private int numEnemy = 0;
    private int spawnedEnemy = 0;
    //----------------------------------
    // End of Enemy Settings
    //----------------------------------
 
   
    // The ID of the spawner
    private int SpawnID;
   
    //----------------------------------
    // Different Spawn states and ways of doing them
    //----------------------------------
    public bool Spawn = true;
    // public SpawnTypes spawnType = SpawnTypes.Normal;

    //----------------------------------
    // End of Different Spawn states and ways of doing them
    //----------------------------------
   
    void Start()
    {
        // sets a random number for the id of the spawner
        SpawnID = Random.Range(1, 500);
    }
   
    // Draws a cube to show where the spawn point is... Useful if you don't have a object that show the spawn point
    void OnDrawGizmos()
    {
        // Sets the color to red
        Gizmos.color = Color.red;
        //draws a small cube at the location of the gam object that the script is attached to
        Gizmos.DrawCube(transform.position, new Vector3 (0.5f,0.5f,0.5f));
    }
   
    void Update ()
    {
        if(Spawn)
        {
            // checks to see if the number of spawned enemies is less than the max num of enemies
            if(numEnemy < totalEnemy)
            {
                // spawns an enemy
                spawnEnemy();
            }
        }
    }
    // spawns an enemy based on the enemy level that you selected
    private void spawnEnemy()
    {

        // Checks to see if there is a gameobject in the easy enemy var
        NPC_IA_Model = NPC_IA_model_maganer.singleton.generarModeloAleatorio();
        if (NPC_IA_Model != null)
        {
            // spawns the enemy
            GameObject Enemy = (GameObject) Instantiate(NPC_IA_Model, gameObject.transform.position, Quaternion.identity);
            // calls a function on the enemy that applies the spawner's ID to the enemy
            Enemy.SendMessage("setName", SpawnID);
        }
        else
        {
            //Shows a debug message if there is no prefab
            Debug.Log("ERROR: No easy enemy Prefab loaded");
        }

        // Increase the total number of enemies spawned and the number of spawned enemies
        numEnemy++;
        spawnedEnemy++;
    }

    //enable the spawner based on spawnerID
    public void enableSpawner(int sID)
    {
        if (SpawnID == sID)
        {
            Spawn = true;
        }
    }
    //disable the spawner based on spawnerID
    public void disableSpawner(int sID)
    {
        if(SpawnID == sID)
        {
            Spawn = false;
        }
    }

    // Enable the spawner, useful for trigger events because you don't know the spawner's ID.
    public void enableTrigger()
    {
        Spawn = true;
    }
}
