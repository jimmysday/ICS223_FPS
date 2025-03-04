using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    //private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 1, 5);

    private int enemyNumber = 5;
    private GameObject[] enemies; // Array to hold enemy instances

    [SerializeField]
    private GameObject iguanaPrefab;
    private int iguanaNumber = 8;
    private GameObject[] iguanas;
    [SerializeField]
    private Transform iguanaSpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the array with the number of enemies to spawn
        enemies = new GameObject[enemyNumber];

        // Loop through the array and instantiate enemies at the start
        for (int i = 0; i < enemyNumber; i++)
        {
            SpawnEnemy(i);
        }

        iguanas = new GameObject[iguanaNumber];

        for (int i = 0; i < iguanaNumber; i++)
        {
            SpawnIguana(i);
        }
    }

    // Helper function to spawn an enemy
    private void SpawnEnemy(int index)
    {
        enemies[index] = Instantiate(enemyPrefab) as GameObject;
       // enemy.transform.position = spawnPoint;
        float angle = Random.Range(0, 360); // Random rotation angle
        enemies[index].transform.Rotate(0, angle, 0); // Apply rotation
    }

    // Helper function to spawn an enemy
    private void SpawnIguana(int index)
    {
        Debug.Log("iguana spawn");
        iguanas[index] = Instantiate(iguanaPrefab) as GameObject;
        iguanas[index].transform.position = iguanaSpawnPoint.position;
        float angle = Random.Range(0, 360); // Random rotation angle
        iguanas[index].transform.Rotate(0, angle, 0); // Apply rotation
    }

    // Update is called once per frame
    void Update()
    {
        //if (enemy == null)
        //{
        //    enemy = Instantiate(enemyPrefab) as GameObject;
        //    enemy.transform.position = spawnPoint;
        //    float angle = Random.Range(0, 360);
        //    enemy.transform.Rotate(0, angle, 0);
        //}
        // Loop through the array to check for null and respawn enemies
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) // If an enemy has been destroyed, respawn it
            {
                SpawnEnemy(i);
            }
        }
    }
}
