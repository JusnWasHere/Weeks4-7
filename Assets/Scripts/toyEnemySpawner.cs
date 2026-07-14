using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class toyEnemySpawner : MonoBehaviour
{

    int side;//to randomly select side of screen later
    Vector3 spawnPosition;//to set where I want the toyEnemy to spawn
    public GameObject enemyPrefab;//the game object prefab of toy enemy

    //timer for spawn interval
    public float duration = 10f;
    public float progress;

    public toyEnemy enemy;//the script on enemy prefab

    public SpriteRenderer barrelSprite;//the sprite of the gun barrel
    public SpriteRenderer turretSprite;//the sprite of the turret body

    public TMP_Text difficultyText;//the text representing difficuly slider value

    public float c;//to set the color of turret later

    //public bool destroyEnemies;


    public List<GameObject> enemies;//a list of all spawned enemy prefabs

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Debug.Log("Screen Width : " + Screen.width);
        
    }

    // Update is called once per frame
    void Update()
    {
        progress += 1 * Time.deltaTime;//progresses the spawn interval timer
        if(progress >= duration)//when that many seconds has passed do this
        {
           
            SpawnEnemy();//invoke spawn enemy fucntion that spawns the enemy
            progress = 0;//resets timer so it waits before spawning another one
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


        for (int i = 0; i < enemies.Count; i++)//removes any indexes that have no enemy when they destroy themselves when killed or reaching turret.
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);

        }
    }

    public void SpawnEnemy()//spawns the enemy
    {
        side = Random.Range(0, 4);//random number between 0 and 3 to pick random side

        /*
         each of these if statments sets the spawn position on the random side picked with a random lcoation along that side. e.g left side of screen at a random y value.
        it then instantiates an enemy prefab at that position
        then it gets the toy enemy script of that specific enemy just spawned
        it then sets the turret script variable in its code to the turret script on this game object. you have to do it this way since we couldnt use find object and since its a prefab can't drag and drop
        it then adds this spawned enemy to the enemies list for checking collisions and other things.
        */

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
        duration = 10-spawnInterval;//changes how fast the enemies spawn based on spawn interval by altering duration
        difficultyText.text = ("Difficulty: " + spawnInterval);//makes sure the difficulty text tells you how hard it is. difficulty 9 means spawn interval is 1 second so its the hardest
        //Debug.Log(spawnInterval);
        c=spawnInterval/10f;//changes the c value to a range of 0.1 to 0.9

        //changes r value of rgb of the sprites so it gets redder the higher the difficulty
        turretSprite.color = new Color(c, 0.1f, 0.1f);
        barrelSprite.color = new Color(c, 0.1f, 0.1f);
        //Debug.Log(c);

        

    }
}
