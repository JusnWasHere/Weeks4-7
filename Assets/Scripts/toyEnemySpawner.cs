using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class toyEnemySpawner : MonoBehaviour
{
    int side;
    Vector3 spawnPosition;
    public GameObject enemyPrefab;

    public float duration = 10f;
    public float progress;

    public toyEnemy enemy;

    public SpriteRenderer barrelSprite;
    public SpriteRenderer turretSprite;

    public TMP_Text difficultyText;

    public float c;

    public bool destroyEnemies;


    public List<GameObject> enemies;
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

        /*
        if(destroyEnemies)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
            destroyEnemies = false;
        }
        */
    }

    public void SpawnEnemy()
    {
        side = Random.Range(0, 4);
        //left side
        if (side == 0)
        {
            spawnPosition.x = -17f;
            spawnPosition.y = Random.Range(-11f, 11f);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();
            enemies.Add(spawnedEnemy);
        }

        //top side
        else if (side == 1)
        {
            spawnPosition.x = Random.Range(-17f, 17f);
            spawnPosition.y = 11f;
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();
            enemies.Add(spawnedEnemy);

        }
        //right side
        else if (side == 2)
        {
            spawnPosition.x = 17f;
            spawnPosition.y = Random.Range(-11f, 11f);
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();
            enemies.Add(spawnedEnemy);

        }
        //bottom side
        else if (side == 3)
        {
            spawnPosition.x = Random.Range(-17f, 17f);
            spawnPosition.y = -11f;
            spawnPosition.z = 0f;
            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy = spawnedEnemy.GetComponent<toyEnemy>();
            enemy.turretScript = GetComponent<Turret>();
            enemies.Add(spawnedEnemy);


        }

    }

    public void OnSliderChange(float spawnInterval)
    {
        duration = 10-spawnInterval;
        difficultyText.text = ("Difficulty: " + spawnInterval);
        //Debug.Log(spawnInterval);
        c=spawnInterval/10f;
        turretSprite.color = new Color(c, 0.1f, 0.1f);
        barrelSprite.color = new Color(c, 0.1f, 0.1f);
        //Debug.Log(c);

        

    }
}
