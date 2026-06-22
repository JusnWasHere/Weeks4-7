using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    public float speed;

    Vector3 currentRotation;



    public GameObject bullet;
    public Bullet bulletScript;

    public List<GameObject> bullets;

    public int killCount = 0;
    public TMP_Text killCountText;

    float timer = 120;
    public TMP_Text timerUI;

    //public Image rightButton;
    //public Image leftButton;

    //public bool turningLeft;
    //public bool turningRight;

    public bool fire;

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
        bool turningRight = Keyboard.current.dKey.isPressed;
        bool turningLeft = Keyboard.current.aKey.isPressed;
        //bool fire = Keyboard.current.spaceKey.wasPressedThisFrame;


        if (turningRight)
        {
            currentRotation.z -= speed * Time.deltaTime;
        }
        else if (turningLeft)
        {
            currentRotation.z += speed * Time.deltaTime;
        }


        if(fire)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletScript = newBullet.GetComponent<Bullet>();
            bulletScript.turret = gameObject;
            bullets.Add(newBullet);
            fire = false;


        }

        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] == null)
                bullets.RemoveAt(i);
            
        }

       

        killCountText.text = "Kills: " + killCount;

        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerUI.text = timeText;


        transform.eulerAngles = currentRotation;
    }

    public void fireClick()
    {
        fire = true;

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
