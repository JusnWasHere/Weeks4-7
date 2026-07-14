using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ToyManager : MonoBehaviour
{

    //the ui/canvas of all 3 screens
    public Canvas battleUI;
    public Canvas LossScreen;
    public Canvas winScreen;

    public GameObject turret;//the turret game object
    public Turret turretScript;//the turret script
    public toyEnemySpawner spawner;//the toy enemy spawner script
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LossScreen.enabled = false;//disables loss screen canvas
        winScreen.enabled = false;//disables win screen canvas


    }

    // Update is called once per frame
    void Update()
    {
        if(turretScript.currentHealth <= 0)//if the turret/player dies
        {
            turret.SetActive(false);//diable turret so cant use it anymore
            battleUI.enabled = false;//disable the in game UI like fire button, health bar etc
            LossScreen.enabled = true;//enable loss screen canvas and ui
            for (int i = 0; i < spawner.enemies.Count; i++)//delete all the enemies in list so not there if you play again.
            {
                Destroy(spawner.enemies[i]);
                spawner.enemies.RemoveAt(i);
            }


        }

        if(turretScript.timer <= 0)//if timer reaches 0/you survived
        {
            turret.SetActive(false);//diable turret so cant use it anymore
            battleUI.enabled = false;//disable the in game UI like fire button, health bar etc
            winScreen.enabled = true;//enable win screen canvas and ui
            for (int i = 0; i < spawner.enemies.Count; i++)//delete all the enemies in list so not there if you play again.
            {
                Destroy(spawner.enemies[i]);
                spawner.enemies.RemoveAt(i);
            }


        }
        
    }

    public void ResetGame()//activated if you hit play again button on win or loss screen
    {
        turret.SetActive(true);//turns turret back on for player to use
        turretScript.currentHealth = 100;//resets player/turret health to full
        battleUI.enabled = true;//enables the ui so can edit difficulty and fire again
        turretScript.timer = 120;//resets timer
        turretScript.killCount = 0;//resets kill count
        LossScreen.enabled = false;//disables loss screen
        winScreen.enabled = false;//disable win screen


    }
}
