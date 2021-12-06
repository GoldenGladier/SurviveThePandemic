// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AISpawner : MonoBehaviour
// {
//     public Transform Player;
//     public int NumberOfEnemiesToSpawn;
//     public float SpawnDelay = 1f;
//     public List<Enemy> EnemyPrefabs = new List<Enemy>();
//     public SpawnMethod EnemySpawnMethod = SpawnMethod.RoundRobin;

//     private Dictionary<int, ObjectPool> EnemyObjectPools = new Dictionary<int, ObjectPool>();

//     private void Awake(){
//         for(int i = 0; i < EnemyPrefabs.Count; i++){
//             EnemyObjectPools.Add(i, ObjectPool.CreateInstance(EnemyPrefabs[i], NumberOfEnemiesToSpawn));
//         }
//     }

//     private void Start(){
//         StartCoroutine(SpawnEnemies());
//     }

//     private IEnumerator SpawnEnemies(){
//         WaitForSeconds Wait = new WaitForSeconds(SpawnDelay);
//         int SpawnEnemies = 0;
        
//         while(SpawnEnemies < NumberOfEnemiesToSpawn){
//             if(EnemySpawnMethod == SpawnMethod.RoundRobin){
//                 SpawnRoundRobinEnemy(SpawnedEnemies);
//             }
//             SpawnedEnemies++;
//             yield return Wait;
//         }
//     }

//     private void SpawnRoundRobinEnemy(int SpawnedEnemies){
//         int SpawnIndex = SpawnedEnemies % EnemyPrefabs.Count;
//         DoSpawnEnemy(SpawnIndex);
//     }

//     private void SpawnRandomEnemy(){
//         DoSpawnEnemy(Random.Range(0, EnemyPrefabs.Count));
//     }

//     private void DoSpawnEnemy(int SpawnIndex){
//         PoolableObject poolableObject = EnemyObjectPools[SpawnIndex].GetObject();

//         if(poolableObject != null){
//             Enemy enemy = poolableObject.GetComponent<Enemy>();
//             NavMeshTriangulation Triangulation = NavMesh.CalculateTriangulation();
//             int VertexIndex = Random.Range(0, Triangulation.vetices.Length);
//             NavMesh Hit;

//             if(NavMesh.SamplePosition(Triangulation.vertices[VertexIndex], out Hit, 2f, 0)){
//                 enemy.Agent.Warp(Hit.position);
//                 enemy.Movement.Player = Player;
//                 enemy.Agent.enabled = true;
//             }
//         }
//         else{
//             Debug.Log($"Unable to fetch enemy of type {SpawnIndex} from object pool. Out of objects?");
//         }
//     }

//     public enum SpawnMethod{
//         RoundRobin,
//         Random
//     }
// }

