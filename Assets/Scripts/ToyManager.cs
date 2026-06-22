using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ToyManager : MonoBehaviour
{

    public Canvas battleUI;
    public Canvas LossScreen;
    public Canvas winScreen;

    public GameObject turret;
    public Turret turretScript;
    public toyEnemySpawner spawner;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LossScreen.enabled = false;
        winScreen.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(turretScript.currentHealth <= 0)
        {
            turret.SetActive(false);
            battleUI.enabled = false;
            LossScreen.enabled = true;
            for (int i = 0; i < spawner.enemies.Count; i++)
            {
                Destroy(spawner.enemies[i]);
                spawner.enemies.RemoveAt(i);
            }


        }

        if(turretScript.timer <= 0)
        {
            turret.SetActive(false);
            battleUI.enabled = false;
            winScreen.enabled = true;
            for (int i = 0; i < spawner.enemies.Count; i++)
            {
                Destroy(spawner.enemies[i]);
                spawner.enemies.RemoveAt(i);
            }


        }
        
    }

    public void ResetGame()
    {
        turret.SetActive(true);
        turretScript.currentHealth = 100;
        battleUI.enabled = true;
        turretScript.timer = 120;
        turretScript.killCount = 0;
        LossScreen.enabled = false;
        winScreen.enabled = false;
        spawner.destroyEnemies = true;


    }
}
