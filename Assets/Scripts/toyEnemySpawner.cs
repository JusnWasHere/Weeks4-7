using UnityEngine;

public class toyEnemySpawner : MonoBehaviour
{
    int side;
    Vector3 spawnPosition;
    public GameObject enemyPrefab;

    public float duration;
    public float progress;

    public toyEnemy enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Screen Width : " + Screen.width);
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += 1 * Time.deltaTime;
        if(progress >= duration)
        {
            SpawnEnemy();
            progress = 0;
        }
        
    }

    public void SpawnEnemy()
    {
        side = Random.Range(0, 4);
        //left side
        if (side == 0)
        {
            spawnPosition.x = -10f;
            spawnPosition.y = Random.Range(-6f, 6f);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();
        }

        //top side
        else if (side == 1)
        {
            spawnPosition.x = Random.Range(-10f, 10f);
            spawnPosition.y = 10f;
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();

        }
        //right side
        else if (side == 2)
        {
            spawnPosition.x = 10f;
            spawnPosition.y = Random.Range(-6f, 6f);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();

        }
        //bottom side
        else if (side == 3)
        {
            spawnPosition.x = Random.Range(-10f, 10f);
            spawnPosition.y = -10f;
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();


        }

    }
}
