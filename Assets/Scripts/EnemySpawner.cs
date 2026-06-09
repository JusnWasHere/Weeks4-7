using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public GameObject existingRunner;
    public List<GameObject> enemies;
    public Canvas victory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victory.enabled = false;
        for (int i = 0; i < 5; i++)
        {
            Vector3 camPos = new Vector3(Random.Range(0.05f, 0.9f), Random.Range(0.05f, 0.9f), 0f);
            Vector3 spawnPos = Camera.main.ViewportToWorldPoint(camPos);
            spawnPos.z = 0f;

            GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemies.Add(spawnedEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(enemies.Count);
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }
        if(enemies.Count <=0)
        {
            Debug.Log("enemies killed");
            victory.enabled = true;


        }

    }
}
