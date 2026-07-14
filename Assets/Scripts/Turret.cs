using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    public float speed;//speed turret can rotate

    Vector3 currentRotation;//its current rotation

    //health values and bar
    public float currentHealth = 100f;
    public float maxHealth = 100f;
    public Image healthBar;

    //bullet prefabs game object and script
    public GameObject bullet;
    public Bullet bulletScript;


    public List<GameObject> bullets;//list of all spawned bullets

    public int killCount = 0;//int representing how many enemies have been killed

    //the text for the kill count in game, loss screen and win screen
    public TMP_Text killCountText;
    public TMP_Text killCountText2;
    public TMP_Text killCountText3;

    //timer for how long you have to survive and text variable that will show the player
    public float timer = 120;
    public TMP_Text timerUI;

  

    //public Image rightButton;
    //public Image leftButton;

    //public bool turningLeft;
    //public bool turningRight;

    public bool fire;//checks if fire button was pressed

    private void Start()
    {
        
    }

    void Update()
    {
        /*
        //bool turningRight = Keyboard.current.rightArrowKey.isPressed;
        //bool turningLeft = Keyboard.current.leftArrowKey.isPressed;
        bool mousePressed = Mouse.current.leftButton.isPressed;
        Vector3 currentMousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        worldMousePosition.z = 0f;

        
        if (mousePressed && rightButton.bounds.Contains(worldMousePosition))
        {
            turningRight = true;
        }
        if (mousePressed && leftButton.bounds.Contains(worldMousePosition))
        {
            turningLeft = true;
        }
        */
        bool turningRight = Keyboard.current.dKey.isPressed;//true if d key was pressed
        bool turningLeft = Keyboard.current.aKey.isPressed;//true if a key was pressed
        //bool fire = Keyboard.current.spaceKey.wasPressedThisFrame;


        if (turningRight)//if d key was pressed turn the z rotation right(-) by speed
        {
            currentRotation.z -= speed * Time.deltaTime;
        }
        else if (turningLeft)//if a key was pressed turn the z rotation left(+) by speed
        {
            currentRotation.z += speed * Time.deltaTime;
        }


        if(fire)//if fire was true aka button pressed
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);//make a new bullet prefab in scene at the turrets position
            bulletScript = newBullet.GetComponent<Bullet>();//get the bullet script
            bulletScript.turret = gameObject;//assign the bullets turret variable to this game object so it knows what the transform.up is
            bullets.Add(newBullet);//add bullet to the list
            fire = false;//make fire false so it only spawns one bullet


        }

        for (int i = 0; i < bullets.Count; i++)//removes any null/empty bullets in list when theyve been destroyed because of collision or going out og bounds
        {
            if (bullets[i] == null)
                bullets.RemoveAt(i);
            
        }

       
        //displaying how many enemies have been killed on all 3 game screens
        killCountText.text = "Kills: " + killCount;
        killCountText2.text = "Kills: " + killCount;
        killCountText3.text = "Kills: " + killCount;

        //Timer code. Basic countdown from 120 but converts it to minutes and seconds and displays it as timers usually do. as put in reflection i did steal that string line because I didnt know what I could change and we just happened to use the same variable names so feel free to comment that out if thats not ok
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerUI.text = timeText;


        transform.eulerAngles = currentRotation;//actually rotates the turret(barrel is attached as child in direction of transform.up so it always looks like bullets coming out of barrel

        healthBar.fillAmount = currentHealth / maxHealth;//displays the turret/player health ui bar
    }

    public void fireClick()//if fire button was clicked
    {
        fire = true;//fire is now true


    }
    /*
    public void clickingRight()
    {
        turningRight = !turningRight;

    }

    public void clickingLeft()
    {
        turningLeft = !turningLeft;

    }
    */


}
