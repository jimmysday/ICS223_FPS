using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    //private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 1, 5);

    private int enemyNumber = 5;
    private GameObject[] enemies; // Array to hold enemy instances

    [SerializeField] private GameObject iguanaPrefab;
    private int iguanaNumber = 8;
    private GameObject[] iguanas;

    [SerializeField] private Transform iguanaSpawnPoint;

    [SerializeField] private UIManager ui;

    private int score = 0;
    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.AddListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.AddListener(GameEvent.RESTART_GAME, OnRestartGame);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
        Messenger.RemoveListener(GameEvent.PLAYER_DEAD, OnPlayerDead);
        Messenger.RemoveListener(GameEvent.RESTART_GAME, OnRestartGame);
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(0);
    }
    private void OnPlayerDead()
    {
        ui.ShowGameOverPopup();
    }

    private void OnEnemyDead()
    {
        score++;
        ui.UpdateScore(score);
    }

    private void OnDifficultyChanged(int newDifficulty) {

        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemies.Length; i++)
        {
            WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialize the array with the number of enemies to spawn
        enemies = new GameObject[enemyNumber];

        ui.UpdateScore(score);
        // other initializations that already exist

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
        iguanas[index] = Instantiate(iguanaPrefab) as GameObject;
        iguanas[index].transform.position = iguanaSpawnPoint.position;
        float angle = Random.Range(0, 360); // Random rotation angle
        iguanas[index].transform.Rotate(0, angle, 0); // Apply rotation
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) // If an enemy has been destroyed, respawn it
            {
                SpawnEnemy(i);
            }

            if (enemies[i])
            {
                int difficulty = GetDifficulty();
                WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
                ai.SetDifficulty(difficulty);
            }
        }
    }

}
