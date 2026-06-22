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
        //LossScreen.enabled = false;
        //winScreen.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if(turretScript.currentHealth <= 0)
        {
            turret.SetActive(false);
            LossScreen.gameObject.SetActive(true);
            //battleUI.enabled = false;
            //LossScreen.enabled = true;
            battleUI.gameObject.SetActive(false);
            spawner.destroyEnemies = true;

        }

        if(turretScript.timer <= 0)
        {
            turret.SetActive(false);
            battleUI.gameObject.SetActive(false);
            winScreen.gameObject.SetActive(true);
            //battleUI.enabled = false;
            //winScreen.enabled = true;
            spawner.destroyEnemies = true;

        }
        
    }

    public void ResetGame()
    {
        turret.SetActive(true);
        turretScript.currentHealth = 100;
        battleUI.enabled = true;
        turretScript.timer = 120;
        turretScript.killCount = 0;
  

    }
}
